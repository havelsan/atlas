
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
    /// Hemşirelik Hizmetleri Hasta Ön Değerlendirme Raporu
    /// </summary>
    public partial class NursingFallingDownRiskReport : TTReport
    {
#region Methods
   public class FunctionDetail{
            public string functionName;
            public List<DetailObject> detailObjectList;
        }
        
        public class DetailObject{
            public string BILGI;
            public string PUAN;
            public string TARIH;
            public string OBJECTID;
            public string NEDEN;
            public string HEMSIRE;
            public int TOTALSCORE;
        }
        
        public int mainCounter = 0;
        public int detailObjectCounter = 0;
        public int detailObjectMainBodyCounter = 0;
        public int mainCounterVertical = 0;
        public DateTime currentDateTime;
        public List<int> tempDetailObjectIndexList;
        List<FunctionDetail> functionDetailList = new List<FunctionDetail>();
   
#endregion Methods

        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class ANAGroup : TTReportGroup
        {
            public NursingFallingDownRiskReport MyParentReport
            {
                get { return (NursingFallingDownRiskReport)ParentReport; }
            }

            new public ANAGroupHeader Header()
            {
                return (ANAGroupHeader)_header;
            }

            new public ANAGroupFooter Footer()
            {
                return (ANAGroupFooter)_footer;
            }

            public ANAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public ANAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new ANAGroupHeader(this);
                _footer = new ANAGroupFooter(this);

            }

            public partial class ANAGroupHeader : TTReportSection
            {
                public NursingFallingDownRiskReport MyParentReport
                {
                    get { return (NursingFallingDownRiskReport)ParentReport; }
                }
                 
                public ANAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 3;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                

                public override void RunScript()
                {
#region ANA HEADER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((NursingFallingDownRiskReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            NursingApplication nursingApplication = (NursingApplication)context.GetObject(new Guid(sObjectID), "NursingApplication");

            List<FunctionDetail> functionDetailList = new List<FunctionDetail>();

            string whereClause = String.Empty;
            List<FallingDownRiskDefinition> FallingDownRiskDefinitionList = new List<FallingDownRiskDefinition>();

            int _age = nursingApplication.Episode.Patient.AgeBySpecificDate(nursingApplication.SubEpisode.OpeningDate.Value); //kabulün alındığı zamanki yaşı
            if (_age <= 16)
                whereClause = " WHERE TYPE = " + (int)FallingDownRiskTypeEnum.Young;
            else
                whereClause = " WHERE TYPE = " + (int)FallingDownRiskTypeEnum.Adult;
            whereClause += " AND ISACTIVE = 1";

            
            FallingDownRiskDefinitionList = FallingDownRiskDefinition.GetFallingDownRiskDefinitions(context, whereClause).ToList();
            List<BaseNursingFallingDownRisk> nursingFallingDownRisks = BaseNursingFallingDownRisk.GetFallingDownRisksByNursingApplication(context,nursingApplication.ObjectID).ToList();
            MyParentReport.mainCounterVertical = nursingFallingDownRisks.Count;
            foreach (FallingDownRiskDefinition fallingDownRisk in FallingDownRiskDefinitionList)
            {
                FunctionDetail newFunctionDetail = new FunctionDetail();
                newFunctionDetail.detailObjectList = new List<DetailObject>();
                newFunctionDetail.functionName = fallingDownRisk.Name;
                
                foreach(BaseNursingFallingDownRisk bFalling in nursingFallingDownRisks)
                {
                    DetailObject detailObject = new DetailObject();
                    detailObject.PUAN = fallingDownRisk.Score.ToString();
                    if(bFalling.ApplicationDate != null)
                        detailObject.TARIH = bFalling.ApplicationDate.Value.ToShortDateString();
                    detailObject.OBJECTID = bFalling.ObjectID.ToString();
                    detailObject.NEDEN = TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(bFalling.FallingDownRiskReason);
                    if(bFalling.TotalScore != null)
                        detailObject.TOTALSCORE = bFalling.TotalScore.Value;
                    if(bFalling.ApplicationUser != null)
                        detailObject.HEMSIRE = bFalling.ApplicationUser.Name;
                    if (bFalling.NursingFallingDownRisks.ToList().Exists(x => x.RiskFactor.ObjectID.Equals(fallingDownRisk.ObjectID)))
                        detailObject.BILGI = "VAR";
                    else
                        detailObject.BILGI = "YOK";
                    newFunctionDetail.detailObjectList.Add(detailObject);
                }
                MyParentReport.functionDetailList.Add(newFunctionDetail);
            }

            MyParentReport.mainCounter = 0;
            
            double d = MyParentReport.mainCounterVertical / 5;
            MyParentReport.NURSINGFALLING.RepeatCount = Convert.ToInt32(Math.Ceiling(d)+1);
            MyParentReport.MAIN.RepeatCount = MyParentReport.functionDetailList.Count();
#endregion ANA HEADER_Script
                }
            }
            public partial class ANAGroupFooter : TTReportSection
            {
                public NursingFallingDownRiskReport MyParentReport
                {
                    get { return (NursingFallingDownRiskReport)ParentReport; }
                }
                 
                public ANAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 6;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public ANAGroup ANA;

        public partial class HEADERGroup : TTReportGroup
        {
            public NursingFallingDownRiskReport MyParentReport
            {
                get { return (NursingFallingDownRiskReport)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField XXXXXXBASLIK111 { get {return Header().XXXXXXBASLIK111;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportShape NewLine12 { get {return Header().NewLine12;} }
            public TTReportShape NewLine111 { get {return Header().NewLine111;} }
            public TTReportShape NewLine1111 { get {return Header().NewLine1111;} }
            public TTReportShape NewLine13 { get {return Header().NewLine13;} }
            public TTReportField NewField1 { get {return Footer().NewField1;} }
            public TTReportField NewField11 { get {return Footer().NewField11;} }
            public TTReportField NewField12 { get {return Footer().NewField12;} }
            public TTReportField NewField112 { get {return Footer().NewField112;} }
            public TTReportField NewField121 { get {return Footer().NewField121;} }
            public TTReportField NewField1211 { get {return Footer().NewField1211;} }
            public TTReportField NewField2 { get {return Footer().NewField2;} }
            public TTReportField NewField3 { get {return Footer().NewField3;} }
            public TTReportShape NewLine113511 { get {return Footer().NewLine113511;} }
            public TTReportShape NewLine113521 { get {return Footer().NewLine113521;} }
            public TTReportShape NewLine113531 { get {return Footer().NewLine113531;} }
            public TTReportShape NewLine113541 { get {return Footer().NewLine113541;} }
            public TTReportShape NewLine113551 { get {return Footer().NewLine113551;} }
            public TTReportShape NewLine113561 { get {return Footer().NewLine113561;} }
            public TTReportShape NewLine1141 { get {return Footer().NewLine1141;} }
            public TTReportShape NewLine11411 { get {return Footer().NewLine11411;} }
            public TTReportShape NewLine121 { get {return Footer().NewLine121;} }
            public TTReportShape NewLine1151 { get {return Footer().NewLine1151;} }
            public TTReportShape NewLine1161 { get {return Footer().NewLine1161;} }
            public TTReportField NewField113 { get {return Footer().NewField113;} }
            public TTReportField NewField122 { get {return Footer().NewField122;} }
            public TTReportField NewField131 { get {return Footer().NewField131;} }
            public TTReportField NewField1131 { get {return Footer().NewField1131;} }
            public TTReportField NewField1141 { get {return Footer().NewField1141;} }
            public TTReportField NewField1151 { get {return Footer().NewField1151;} }
            public TTReportField NewField1161 { get {return Footer().NewField1161;} }
            public TTReportField NewField1171 { get {return Footer().NewField1171;} }
            public TTReportField NewField1181 { get {return Footer().NewField1181;} }
            public TTReportField NewField1191 { get {return Footer().NewField1191;} }
            public TTReportField NewField1201 { get {return Footer().NewField1201;} }
            public TTReportField NewField1212 { get {return Footer().NewField1212;} }
            public TTReportField NewField1111 { get {return Footer().NewField1111;} }
            public TTReportShape NewRect111 { get {return Footer().NewRect111;} }
            public TTReportShape NewRect1111 { get {return Footer().NewRect1111;} }
            public TTReportShape NewRect1121 { get {return Footer().NewRect1121;} }
            public TTReportShape NewRect1131 { get {return Footer().NewRect1131;} }
            public TTReportShape NewRect1141 { get {return Footer().NewRect1141;} }
            public TTReportShape NewRect1151 { get {return Footer().NewRect1151;} }
            public TTReportShape NewRect1161 { get {return Footer().NewRect1161;} }
            public TTReportShape NewRect1171 { get {return Footer().NewRect1171;} }
            public TTReportShape NewRect1181 { get {return Footer().NewRect1181;} }
            public TTReportShape NewRect1191 { get {return Footer().NewRect1191;} }
            public TTReportShape NewRect1201 { get {return Footer().NewRect1201;} }
            public TTReportField NewField1121 { get {return Footer().NewField1121;} }
            public TTReportField NewField1251 { get {return Footer().NewField1251;} }
            public TTReportField NewField11511 { get {return Footer().NewField11511;} }
            public TTReportField NewField11521 { get {return Footer().NewField11521;} }
            public TTReportField NewField111511 { get {return Footer().NewField111511;} }
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
                public NursingFallingDownRiskReport MyParentReport
                {
                    get { return (NursingFallingDownRiskReport)ParentReport; }
                }
                
                public TTReportField NewField111;
                public TTReportField XXXXXXBASLIK111;
                public TTReportField LOGO;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportShape NewLine12;
                public TTReportShape NewLine111;
                public TTReportShape NewLine1111;
                public TTReportShape NewLine13; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 57;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 40, 195, 48, false);
                    NewField111.Name = "NewField111";
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"Hemşirelik Düşme Riski Değerlendirme Raporu";

                    XXXXXXBASLIK111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 8, 194, 38, false);
                    XXXXXXBASLIK111.Name = "XXXXXXBASLIK111";
                    XXXXXXBASLIK111.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK111.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK111.NoClip = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK111.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK111.ExpandTabs = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK111.TextFont.Size = 11;
                    XXXXXXBASLIK111.TextFont.Bold = true;
                    XXXXXXBASLIK111.TextFont.CharSet = 162;
                    XXXXXXBASLIK111.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 12, 45, 35, false);
                    LOGO.Name = "LOGO";
                    LOGO.FieldType = ReportFieldTypeEnum.ftOLE;
                    LOGO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO.ExpandTabs = EvetHayirEnum.ehEvet;
                    LOGO.ObjectDefName = "HospitalEmblemDefinition";
                    LOGO.DataMember = "EMBLEM";
                    LOGO.TextFont.Name = "Courier New";
                    LOGO.Value = @"";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 7, 14, 49, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 7, 197, 7, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 197, 7, 197, 49, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 39, 197, 39, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 49, 197, 49, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 47, 7, 47, 39, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111.CalcValue = NewField111.Value;
                    LOGO.CalcValue = @"";
                    XXXXXXBASLIK111.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { NewField111,LOGO,XXXXXXBASLIK111};
                }

                public override void RunScript()
                {
#region HEADER HEADER_Script
                    this.LOGO.CalcValue = TTObjectClasses.Common.GetCurrentHospitalLogo();
#endregion HEADER HEADER_Script
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public NursingFallingDownRiskReport MyParentReport
                {
                    get { return (NursingFallingDownRiskReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField112;
                public TTReportField NewField121;
                public TTReportField NewField1211;
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportShape NewLine113511;
                public TTReportShape NewLine113521;
                public TTReportShape NewLine113531;
                public TTReportShape NewLine113541;
                public TTReportShape NewLine113551;
                public TTReportShape NewLine113561;
                public TTReportShape NewLine1141;
                public TTReportShape NewLine11411;
                public TTReportShape NewLine121;
                public TTReportShape NewLine1151;
                public TTReportShape NewLine1161;
                public TTReportField NewField113;
                public TTReportField NewField122;
                public TTReportField NewField131;
                public TTReportField NewField1131;
                public TTReportField NewField1141;
                public TTReportField NewField1151;
                public TTReportField NewField1161;
                public TTReportField NewField1171;
                public TTReportField NewField1181;
                public TTReportField NewField1191;
                public TTReportField NewField1201;
                public TTReportField NewField1212;
                public TTReportField NewField1111;
                public TTReportShape NewRect111;
                public TTReportShape NewRect1111;
                public TTReportShape NewRect1121;
                public TTReportShape NewRect1131;
                public TTReportShape NewRect1141;
                public TTReportShape NewRect1151;
                public TTReportShape NewRect1161;
                public TTReportShape NewRect1171;
                public TTReportShape NewRect1181;
                public TTReportShape NewRect1191;
                public TTReportShape NewRect1201;
                public TTReportField NewField1121;
                public TTReportField NewField1251;
                public TTReportField NewField11511;
                public TTReportField NewField11521;
                public TTReportField NewField111511; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 196;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 54, 105, 89, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"*KRONİK HASTALIKLAR";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 54, 204, 89, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @" - Hipertansiyon
 - Diyabet
 - Dolaşım Sistemi Hastalıkları
 - Sindirim Sistemi Hastalıkları
 - Artrit
 - Paralizi
 - Depresyon
 - Nörolojik Hastalıklar";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 89, 105, 120, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"**HASTA BAKIM EKİPMANLARI";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 89, 204, 120, false);
                    NewField112.Name = "NewField112";
                    NewField112.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    NewField112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112.TextFont.Bold = true;
                    NewField112.TextFont.CharSet = 162;
                    NewField112.Value = @" - IV İnfüzyon
 - Solunum Cihazı
 - Kalıcı Kateter
 - Göğüs Tüpü
 - Dren
 - Perfüzatör
 - Pacemaker vb.";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 120, 105, 163, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"***RİSKLİ İLAÇLAR";

                    NewField1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 120, 204, 163, false);
                    NewField1211.Name = "NewField1211";
                    NewField1211.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    NewField1211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1211.TextFont.Bold = true;
                    NewField1211.TextFont.CharSet = 162;
                    NewField1211.Value = @" - Psikotroplar
 - Narkotikler
 - Benzodiazepinler
 - Nöroleptikler
 - Antikoagülanlar
 - Narkotik Analjezikler
 - Diüretikler/Laksatifler
 - Antidiayebetikler
 - Santral Venöz Sistem İlaçları (Digoksin vb.)
 - Kan Basıncını Düzenleyici İlaçlar";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 163, 204, 168, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"BİLGİLENDİRME TABLOSU";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 168, 204, 195, false);
                    NewField3.Name = "NewField3";
                    NewField3.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    NewField3.MultiLine = EvetHayirEnum.ehEvet;
                    NewField3.WordBreak = EvetHayirEnum.ehEvet;
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"Aşağıda belirtilen beş durumda düşme riski değerlendirmesi yapılmalı ve her defasında yeni bir form kullanılmalıdır.
- Yatan hastaların bölüme ilk kabulünde (İlk Değerlendirme),
- Post- Operatif dönemde,
- Bölüm değişikliğinde,
- Hasta düşmesi durumunda,
- Risk faktörleri kapsamındaki durum değişikliklerinde.";

                    NewLine113511 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 22, 204, 22, false);
                    NewLine113511.Name = "NewLine113511";
                    NewLine113511.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine113521 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 29, 204, 29, false);
                    NewLine113521.Name = "NewLine113521";
                    NewLine113521.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine113531 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 35, 204, 35, false);
                    NewLine113531.Name = "NewLine113531";
                    NewLine113531.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine113541 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 41, 204, 41, false);
                    NewLine113541.Name = "NewLine113541";
                    NewLine113541.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine113551 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 47, 204, 47, false);
                    NewLine113551.Name = "NewLine113551";
                    NewLine113551.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine113561 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 54, 204, 54, false);
                    NewLine113561.Name = "NewLine113561";
                    NewLine113561.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1141 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 22, 8, 54, false);
                    NewLine1141.Name = "NewLine1141";
                    NewLine1141.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11411 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 204, 22, 204, 54, false);
                    NewLine11411.Name = "NewLine11411";
                    NewLine11411.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 60, 29, 60, 47, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1151 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 110, 29, 110, 47, false);
                    NewLine1151.Name = "NewLine1151";
                    NewLine1151.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1161 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 160, 29, 160, 41, false);
                    NewLine1161.Name = "NewLine1161";
                    NewLine1161.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 23, 204, 28, false);
                    NewField113.Name = "NewField113";
                    NewField113.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField113.TextFont.Size = 11;
                    NewField113.TextFont.Bold = true;
                    NewField113.TextFont.CharSet = 162;
                    NewField113.Value = @"DÜŞME RİSKİNİ ÖNLEMEDE ALINAN GÜVENLİK ÖNLEMLERİ";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 30, 59, 34, false);
                    NewField122.Name = "NewField122";
                    NewField122.Value = @"Yatak en düşük seviyede";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 30, 109, 34, false);
                    NewField131.Name = "NewField131";
                    NewField131.Value = @"Yatak başı düzenli";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 30, 159, 34, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.Value = @"Refakatçi mevcut";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 30, 204, 34, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.Value = @"Gereksiz ekipman yok";

                    NewField1151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 36, 59, 40, false);
                    NewField1151.Name = "NewField1151";
                    NewField1151.Value = @"Yatak kenarları kalkık";

                    NewField1161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 36, 109, 40, false);
                    NewField1161.Name = "NewField1161";
                    NewField1161.Value = @"Oda aydınlatması yeterli";

                    NewField1171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 36, 159, 40, false);
                    NewField1171.Name = "NewField1171";
                    NewField1171.Value = @"Oda kapısı açık";

                    NewField1181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 36, 204, 40, false);
                    NewField1181.Name = "NewField1181";
                    NewField1181.Value = @"Diğer";

                    NewField1191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 42, 59, 46, false);
                    NewField1191.Name = "NewField1191";
                    NewField1191.Value = @"Yatak frenleri kapalı";

                    NewField1201 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 42, 109, 46, false);
                    NewField1201.Name = "NewField1201";
                    NewField1201.Value = @"Çağrı sistemi etkin";

                    NewField1212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 42, 204, 46, false);
                    NewField1212.Name = "NewField1212";
                    NewField1212.Value = @"Araç gereçlerden transfer güvenli";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 48, 204, 53, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.Value = @"Not: XXXXXXmizin politikası gereği tüm hastalarımız düşme riski yüksek kabul edilmektedir";

                    NewRect111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 9, 30, 13, 34, false);
                    NewRect111.Name = "NewRect111";
                    NewRect111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 9, 36, 13, 40, false);
                    NewRect1111.Name = "NewRect1111";
                    NewRect1111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect1121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 9, 42, 13, 46, false);
                    NewRect1121.Name = "NewRect1121";
                    NewRect1121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect1131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 61, 30, 65, 34, false);
                    NewRect1131.Name = "NewRect1131";
                    NewRect1131.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect1141 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 61, 36, 65, 40, false);
                    NewRect1141.Name = "NewRect1141";
                    NewRect1141.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect1151 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 61, 42, 65, 46, false);
                    NewRect1151.Name = "NewRect1151";
                    NewRect1151.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect1161 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 111, 30, 115, 34, false);
                    NewRect1161.Name = "NewRect1161";
                    NewRect1161.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect1171 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 111, 36, 115, 40, false);
                    NewRect1171.Name = "NewRect1171";
                    NewRect1171.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect1181 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 111, 42, 115, 46, false);
                    NewRect1181.Name = "NewRect1181";
                    NewRect1181.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect1191 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 161, 30, 165, 34, false);
                    NewRect1191.Name = "NewRect1191";
                    NewRect1191.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect1201 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 161, 36, 165, 40, false);
                    NewRect1201.Name = "NewRect1201";
                    NewRect1201.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 2, 204, 7, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    NewField1121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"RİSK DÜZEYİ BELİRLEME TABLOSU";

                    NewField1251 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 7, 51, 13, false);
                    NewField1251.Name = "NewField1251";
                    NewField1251.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    NewField1251.TextFont.Bold = true;
                    NewField1251.TextFont.CharSet = 162;
                    NewField1251.Value = @"Düşük Risk";

                    NewField11511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 7, 204, 13, false);
                    NewField11511.Name = "NewField11511";
                    NewField11511.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    NewField11511.TextFont.Bold = true;
                    NewField11511.TextFont.CharSet = 162;
                    NewField11511.Value = @"Toplam Puanı 5' in altında";

                    NewField11521 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 13, 51, 19, false);
                    NewField11521.Name = "NewField11521";
                    NewField11521.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    NewField11521.TextFont.Bold = true;
                    NewField11521.TextFont.CharSet = 162;
                    NewField11521.Value = @"Yüksek Risk";

                    NewField111511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 13, 204, 19, false);
                    NewField111511.Name = "NewField111511";
                    NewField111511.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    NewField111511.TextFont.Bold = true;
                    NewField111511.TextFont.CharSet = 162;
                    NewField111511.Value = @"Toplam Puanı 5 ve 5' in üstünde (Dört Yapraklı Yonca figürü kullanılır)";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField112.CalcValue = NewField112.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField1211.CalcValue = NewField1211.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField113.CalcValue = NewField113.Value;
                    NewField122.CalcValue = NewField122.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    NewField1141.CalcValue = NewField1141.Value;
                    NewField1151.CalcValue = NewField1151.Value;
                    NewField1161.CalcValue = NewField1161.Value;
                    NewField1171.CalcValue = NewField1171.Value;
                    NewField1181.CalcValue = NewField1181.Value;
                    NewField1191.CalcValue = NewField1191.Value;
                    NewField1201.CalcValue = NewField1201.Value;
                    NewField1212.CalcValue = NewField1212.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField1251.CalcValue = NewField1251.Value;
                    NewField11511.CalcValue = NewField11511.Value;
                    NewField11521.CalcValue = NewField11521.Value;
                    NewField111511.CalcValue = NewField111511.Value;
                    return new TTReportObject[] { NewField1,NewField11,NewField12,NewField112,NewField121,NewField1211,NewField2,NewField3,NewField113,NewField122,NewField131,NewField1131,NewField1141,NewField1151,NewField1161,NewField1171,NewField1181,NewField1191,NewField1201,NewField1212,NewField1111,NewField1121,NewField1251,NewField11511,NewField11521,NewField111511};
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class PARENTGroup : TTReportGroup
        {
            public NursingFallingDownRiskReport MyParentReport
            {
                get { return (NursingFallingDownRiskReport)ParentReport; }
            }

            new public PARENTGroupHeader Header()
            {
                return (PARENTGroupHeader)_header;
            }

            new public PARENTGroupFooter Footer()
            {
                return (PARENTGroupFooter)_footer;
            }

            public TTReportField ADSOYAD { get {return Header().ADSOYAD;} }
            public TTReportField NewField12211 { get {return Header().NewField12211;} }
            public TTReportField PROTOKOLNO { get {return Header().PROTOKOLNO;} }
            public TTReportField NewField122211 { get {return Header().NewField122211;} }
            public TTReportShape NewLine1241 { get {return Header().NewLine1241;} }
            public TTReportShape NewLine12411 { get {return Header().NewLine12411;} }
            public TTReportShape NewLine121411 { get {return Header().NewLine121411;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportShape NewLine1214111 { get {return Header().NewLine1214111;} }
            public TTReportShape NewLine1214121 { get {return Header().NewLine1214121;} }
            public TTReportShape NewLine1214131 { get {return Header().NewLine1214131;} }
            public TTReportShape NewLine1214141 { get {return Header().NewLine1214141;} }
            public TTReportShape NewLine12214111 { get {return Header().NewLine12214111;} }
            public TTReportShape NewLine121141211 { get {return Header().NewLine121141211;} }
            public TTReportField NewField141 { get {return Header().NewField141;} }
            public TTReportField NewField1221 { get {return Header().NewField1221;} }
            public TTReportField NewField1331 { get {return Header().NewField1331;} }
            public TTReportField NewField1341 { get {return Header().NewField1341;} }
            public TTReportField NewField1351 { get {return Header().NewField1351;} }
            public TTReportField NewField1361 { get {return Header().NewField1361;} }
            public TTReportShape NewLine112 { get {return Header().NewLine112;} }
            public TTReportShape NewLine1251 { get {return Header().NewLine1251;} }
            public TTReportField TCID { get {return Header().TCID;} }
            public TTReportField KLINIK { get {return Header().KLINIK;} }
            public TTReportField CINSIYET { get {return Header().CINSIYET;} }
            public TTReportField YAS { get {return Header().YAS;} }
            public TTReportField KILO { get {return Header().KILO;} }
            public TTReportField BOY { get {return Header().BOY;} }
            public TTReportField TANI { get {return Header().TANI;} }
            public TTReportShape NewLine11511 { get {return Header().NewLine11511;} }
            public TTReportField NewField111211 { get {return Header().NewField111211;} }
            public TTReportField NewField111221 { get {return Header().NewField111221;} }
            public TTReportField NewField111231 { get {return Header().NewField111231;} }
            public TTReportField NewField111241 { get {return Header().NewField111241;} }
            public TTReportField NewField111251 { get {return Header().NewField111251;} }
            public TTReportField NewField111261 { get {return Header().NewField111261;} }
            public TTReportField NewField111271 { get {return Header().NewField111271;} }
            public TTReportField NewField111281 { get {return Header().NewField111281;} }
            public TTReportField NewField111291 { get {return Header().NewField111291;} }
            public TTReportShape NewLine121511 { get {return Header().NewLine121511;} }
            public TTReportField YATIS_TARIHI { get {return Header().YATIS_TARIHI;} }
            public TTReportField YATIS_SAATI { get {return Header().YATIS_SAATI;} }
            public TTReportField CIKIS_TARIHI { get {return Header().CIKIS_TARIHI;} }
            public TTReportField LISAN { get {return Header().LISAN;} }
            public TTReportField EGITIM { get {return Header().EGITIM;} }
            public TTReportField MESLEK { get {return Header().MESLEK;} }
            public TTReportField MEDENIDURUM { get {return Header().MEDENIDURUM;} }
            public TTReportField COCUK { get {return Header().COCUK;} }
            public TTReportField ANT { get {return Header().ANT;} }
            public TTReportShape NewLine1261 { get {return Header().NewLine1261;} }
            public TTReportShape NewLine13411 { get {return Header().NewLine13411;} }
            public PARENTGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARENTGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARENTGroupHeader(this);
                _footer = new PARENTGroupFooter(this);

            }

            public partial class PARENTGroupHeader : TTReportSection
            {
                public NursingFallingDownRiskReport MyParentReport
                {
                    get { return (NursingFallingDownRiskReport)ParentReport; }
                }
                
                public TTReportField ADSOYAD;
                public TTReportField NewField12211;
                public TTReportField PROTOKOLNO;
                public TTReportField NewField122211;
                public TTReportShape NewLine1241;
                public TTReportShape NewLine12411;
                public TTReportShape NewLine121411;
                public TTReportField NewField131;
                public TTReportShape NewLine1214111;
                public TTReportShape NewLine1214121;
                public TTReportShape NewLine1214131;
                public TTReportShape NewLine1214141;
                public TTReportShape NewLine12214111;
                public TTReportShape NewLine121141211;
                public TTReportField NewField141;
                public TTReportField NewField1221;
                public TTReportField NewField1331;
                public TTReportField NewField1341;
                public TTReportField NewField1351;
                public TTReportField NewField1361;
                public TTReportShape NewLine112;
                public TTReportShape NewLine1251;
                public TTReportField TCID;
                public TTReportField KLINIK;
                public TTReportField CINSIYET;
                public TTReportField YAS;
                public TTReportField KILO;
                public TTReportField BOY;
                public TTReportField TANI;
                public TTReportShape NewLine11511;
                public TTReportField NewField111211;
                public TTReportField NewField111221;
                public TTReportField NewField111231;
                public TTReportField NewField111241;
                public TTReportField NewField111251;
                public TTReportField NewField111261;
                public TTReportField NewField111271;
                public TTReportField NewField111281;
                public TTReportField NewField111291;
                public TTReportShape NewLine121511;
                public TTReportField YATIS_TARIHI;
                public TTReportField YATIS_SAATI;
                public TTReportField CIKIS_TARIHI;
                public TTReportField LISAN;
                public TTReportField EGITIM;
                public TTReportField MESLEK;
                public TTReportField MEDENIDURUM;
                public TTReportField COCUK;
                public TTReportField ANT;
                public TTReportShape NewLine1261;
                public TTReportShape NewLine13411; 
                public PARENTGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 56;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    ADSOYAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 2, 114, 6, false);
                    ADSOYAD.Name = "ADSOYAD";
                    ADSOYAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYAD.TextFont.Size = 9;
                    ADSOYAD.TextFont.CharSet = 162;
                    ADSOYAD.Value = @"";

                    NewField12211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 2, 37, 6, false);
                    NewField12211.Name = "NewField12211";
                    NewField12211.TextFont.Bold = true;
                    NewField12211.TextFont.CharSet = 162;
                    NewField12211.Value = @"Adı Soyadı:";

                    PROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 8, 114, 12, false);
                    PROTOKOLNO.Name = "PROTOKOLNO";
                    PROTOKOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOKOLNO.TextFont.Size = 9;
                    PROTOKOLNO.TextFont.CharSet = 162;
                    PROTOKOLNO.Value = @"";

                    NewField122211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 8, 37, 12, false);
                    NewField122211.Name = "NewField122211";
                    NewField122211.TextFont.Size = 9;
                    NewField122211.TextFont.Bold = true;
                    NewField122211.TextFont.CharSet = 162;
                    NewField122211.Value = @"Protokol No:";

                    NewLine1241 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 7, 204, 7, false);
                    NewLine1241.Name = "NewLine1241";
                    NewLine1241.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine12411 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 13, 204, 13, false);
                    NewLine12411.Name = "NewLine12411";
                    NewLine12411.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine121411 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 19, 204, 19, false);
                    NewLine121411.Name = "NewLine121411";
                    NewLine121411.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 14, 37, 18, false);
                    NewField131.Name = "NewField131";
                    NewField131.TextFont.Size = 9;
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 0;
                    NewField131.Value = @"TC Kimlik Nu:";

                    NewLine1214111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 25, 204, 25, false);
                    NewLine1214111.Name = "NewLine1214111";
                    NewLine1214111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1214121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 43, 204, 43, false);
                    NewLine1214121.Name = "NewLine1214121";
                    NewLine1214121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1214131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 31, 204, 31, false);
                    NewLine1214131.Name = "NewLine1214131";
                    NewLine1214131.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1214141 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 37, 204, 37, false);
                    NewLine1214141.Name = "NewLine1214141";
                    NewLine1214141.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine12214111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 49, 204, 49, false);
                    NewLine12214111.Name = "NewLine12214111";
                    NewLine12214111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine121141211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 55, 204, 55, false);
                    NewLine121141211.Name = "NewLine121141211";
                    NewLine121141211.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 20, 37, 24, false);
                    NewField141.Name = "NewField141";
                    NewField141.TextFont.Size = 9;
                    NewField141.TextFont.Bold = true;
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @"Klinik/Servis:";

                    NewField1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 26, 37, 30, false);
                    NewField1221.Name = "NewField1221";
                    NewField1221.TextFont.Size = 9;
                    NewField1221.TextFont.Bold = true;
                    NewField1221.TextFont.CharSet = 162;
                    NewField1221.Value = @"Cinsiyeti:";

                    NewField1331 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 32, 37, 36, false);
                    NewField1331.Name = "NewField1331";
                    NewField1331.TextFont.Size = 9;
                    NewField1331.TextFont.Bold = true;
                    NewField1331.TextFont.CharSet = 162;
                    NewField1331.Value = @"Yaş:";

                    NewField1341 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 38, 37, 42, false);
                    NewField1341.Name = "NewField1341";
                    NewField1341.TextFont.Size = 9;
                    NewField1341.TextFont.Bold = true;
                    NewField1341.TextFont.CharSet = 162;
                    NewField1341.Value = @"Kilo:";

                    NewField1351 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 44, 37, 48, false);
                    NewField1351.Name = "NewField1351";
                    NewField1351.TextFont.Size = 9;
                    NewField1351.TextFont.Bold = true;
                    NewField1351.TextFont.CharSet = 162;
                    NewField1351.Value = @"Boy:";

                    NewField1361 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 50, 37, 54, false);
                    NewField1361.Name = "NewField1361";
                    NewField1361.TextFont.Size = 9;
                    NewField1361.TextFont.Bold = true;
                    NewField1361.TextFont.CharSet = 162;
                    NewField1361.Value = @"Ön Tıbbi Tanı/Tanı:";

                    NewLine112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 38, 1, 38, 55, false);
                    NewLine112.Name = "NewLine112";
                    NewLine112.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1251 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 1, 8, 55, false);
                    NewLine1251.Name = "NewLine1251";
                    NewLine1251.DrawStyle = DrawStyleConstants.vbSolid;

                    TCID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 14, 114, 18, false);
                    TCID.Name = "TCID";
                    TCID.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCID.TextFont.Size = 9;
                    TCID.TextFont.CharSet = 162;
                    TCID.Value = @"";

                    KLINIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 20, 114, 24, false);
                    KLINIK.Name = "KLINIK";
                    KLINIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    KLINIK.TextFont.Size = 9;
                    KLINIK.TextFont.CharSet = 162;
                    KLINIK.Value = @"";

                    CINSIYET = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 26, 114, 30, false);
                    CINSIYET.Name = "CINSIYET";
                    CINSIYET.FieldType = ReportFieldTypeEnum.ftVariable;
                    CINSIYET.TextFont.Size = 9;
                    CINSIYET.TextFont.CharSet = 162;
                    CINSIYET.Value = @"";

                    YAS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 32, 114, 36, false);
                    YAS.Name = "YAS";
                    YAS.FieldType = ReportFieldTypeEnum.ftVariable;
                    YAS.TextFont.Size = 9;
                    YAS.TextFont.CharSet = 162;
                    YAS.Value = @"";

                    KILO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 38, 114, 42, false);
                    KILO.Name = "KILO";
                    KILO.FieldType = ReportFieldTypeEnum.ftVariable;
                    KILO.TextFont.Size = 9;
                    KILO.TextFont.CharSet = 162;
                    KILO.Value = @"";

                    BOY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 44, 114, 48, false);
                    BOY.Name = "BOY";
                    BOY.FieldType = ReportFieldTypeEnum.ftVariable;
                    BOY.TextFont.Size = 9;
                    BOY.TextFont.CharSet = 162;
                    BOY.Value = @"";

                    TANI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 50, 114, 54, false);
                    TANI.Name = "TANI";
                    TANI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TANI.TextFont.Size = 9;
                    TANI.TextFont.CharSet = 162;
                    TANI.Value = @"";

                    NewLine11511 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 116, 1, 116, 55, false);
                    NewLine11511.Name = "NewLine11511";
                    NewLine11511.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 2, 145, 6, false);
                    NewField111211.Name = "NewField111211";
                    NewField111211.TextFont.Bold = true;
                    NewField111211.TextFont.CharSet = 162;
                    NewField111211.Value = @"Yatış Tarihi:";

                    NewField111221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 8, 145, 12, false);
                    NewField111221.Name = "NewField111221";
                    NewField111221.TextFont.Bold = true;
                    NewField111221.TextFont.CharSet = 162;
                    NewField111221.Value = @"Yatış Saati:";

                    NewField111231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 14, 145, 18, false);
                    NewField111231.Name = "NewField111231";
                    NewField111231.TextFont.Bold = true;
                    NewField111231.TextFont.CharSet = 162;
                    NewField111231.Value = @"Çıkış Tarihi:";

                    NewField111241 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 20, 145, 24, false);
                    NewField111241.Name = "NewField111241";
                    NewField111241.TextFont.Bold = true;
                    NewField111241.TextFont.CharSet = 162;
                    NewField111241.Value = @"Kullandığı Lisan:";

                    NewField111251 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 26, 145, 30, false);
                    NewField111251.Name = "NewField111251";
                    NewField111251.TextFont.Bold = true;
                    NewField111251.TextFont.CharSet = 162;
                    NewField111251.Value = @"Eğitimi:";

                    NewField111261 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 32, 145, 36, false);
                    NewField111261.Name = "NewField111261";
                    NewField111261.TextFont.Bold = true;
                    NewField111261.TextFont.CharSet = 162;
                    NewField111261.Value = @"Mesleği:";

                    NewField111271 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 38, 145, 42, false);
                    NewField111271.Name = "NewField111271";
                    NewField111271.TextFont.Bold = true;
                    NewField111271.TextFont.CharSet = 162;
                    NewField111271.Value = @"Medeni Durumu:";

                    NewField111281 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 44, 145, 48, false);
                    NewField111281.Name = "NewField111281";
                    NewField111281.TextFont.Bold = true;
                    NewField111281.TextFont.CharSet = 162;
                    NewField111281.Value = @"Çocuk Sayısı:";

                    NewField111291 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 50, 145, 54, false);
                    NewField111291.Name = "NewField111291";
                    NewField111291.TextFont.Bold = true;
                    NewField111291.TextFont.CharSet = 162;
                    NewField111291.Value = @"ANT:";

                    NewLine121511 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 147, 1, 147, 55, false);
                    NewLine121511.Name = "NewLine121511";
                    NewLine121511.DrawStyle = DrawStyleConstants.vbSolid;

                    YATIS_TARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 2, 204, 6, false);
                    YATIS_TARIHI.Name = "YATIS_TARIHI";
                    YATIS_TARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    YATIS_TARIHI.TextFont.Size = 9;
                    YATIS_TARIHI.TextFont.CharSet = 162;
                    YATIS_TARIHI.Value = @"";

                    YATIS_SAATI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 8, 204, 12, false);
                    YATIS_SAATI.Name = "YATIS_SAATI";
                    YATIS_SAATI.FieldType = ReportFieldTypeEnum.ftVariable;
                    YATIS_SAATI.TextFont.Size = 9;
                    YATIS_SAATI.TextFont.CharSet = 162;
                    YATIS_SAATI.Value = @"";

                    CIKIS_TARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 14, 204, 18, false);
                    CIKIS_TARIHI.Name = "CIKIS_TARIHI";
                    CIKIS_TARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    CIKIS_TARIHI.TextFont.Size = 9;
                    CIKIS_TARIHI.TextFont.CharSet = 162;
                    CIKIS_TARIHI.Value = @"";

                    LISAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 20, 204, 24, false);
                    LISAN.Name = "LISAN";
                    LISAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    LISAN.TextFont.Size = 9;
                    LISAN.TextFont.CharSet = 162;
                    LISAN.Value = @"";

                    EGITIM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 26, 204, 30, false);
                    EGITIM.Name = "EGITIM";
                    EGITIM.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM.TextFont.Size = 9;
                    EGITIM.TextFont.CharSet = 162;
                    EGITIM.Value = @"";

                    MESLEK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 32, 204, 36, false);
                    MESLEK.Name = "MESLEK";
                    MESLEK.FieldType = ReportFieldTypeEnum.ftVariable;
                    MESLEK.TextFont.Size = 9;
                    MESLEK.TextFont.CharSet = 162;
                    MESLEK.Value = @"";

                    MEDENIDURUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 38, 204, 42, false);
                    MEDENIDURUM.Name = "MEDENIDURUM";
                    MEDENIDURUM.FieldType = ReportFieldTypeEnum.ftVariable;
                    MEDENIDURUM.TextFont.Size = 9;
                    MEDENIDURUM.TextFont.CharSet = 162;
                    MEDENIDURUM.Value = @"";

                    COCUK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 44, 204, 48, false);
                    COCUK.Name = "COCUK";
                    COCUK.FieldType = ReportFieldTypeEnum.ftVariable;
                    COCUK.TextFont.Size = 9;
                    COCUK.TextFont.CharSet = 162;
                    COCUK.Value = @"";

                    ANT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 50, 204, 54, false);
                    ANT.Name = "ANT";
                    ANT.FieldType = ReportFieldTypeEnum.ftVariable;
                    ANT.TextFont.Size = 9;
                    ANT.TextFont.CharSet = 162;
                    ANT.Value = @"";

                    NewLine1261 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 204, 1, 204, 55, false);
                    NewLine1261.Name = "NewLine1261";
                    NewLine1261.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine13411 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 1, 204, 1, false);
                    NewLine13411.Name = "NewLine13411";
                    NewLine13411.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ADSOYAD.CalcValue = @"";
                    NewField12211.CalcValue = NewField12211.Value;
                    PROTOKOLNO.CalcValue = @"";
                    NewField122211.CalcValue = NewField122211.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField1221.CalcValue = NewField1221.Value;
                    NewField1331.CalcValue = NewField1331.Value;
                    NewField1341.CalcValue = NewField1341.Value;
                    NewField1351.CalcValue = NewField1351.Value;
                    NewField1361.CalcValue = NewField1361.Value;
                    TCID.CalcValue = @"";
                    KLINIK.CalcValue = @"";
                    CINSIYET.CalcValue = @"";
                    YAS.CalcValue = @"";
                    KILO.CalcValue = @"";
                    BOY.CalcValue = @"";
                    TANI.CalcValue = @"";
                    NewField111211.CalcValue = NewField111211.Value;
                    NewField111221.CalcValue = NewField111221.Value;
                    NewField111231.CalcValue = NewField111231.Value;
                    NewField111241.CalcValue = NewField111241.Value;
                    NewField111251.CalcValue = NewField111251.Value;
                    NewField111261.CalcValue = NewField111261.Value;
                    NewField111271.CalcValue = NewField111271.Value;
                    NewField111281.CalcValue = NewField111281.Value;
                    NewField111291.CalcValue = NewField111291.Value;
                    YATIS_TARIHI.CalcValue = @"";
                    YATIS_SAATI.CalcValue = @"";
                    CIKIS_TARIHI.CalcValue = @"";
                    LISAN.CalcValue = @"";
                    EGITIM.CalcValue = @"";
                    MESLEK.CalcValue = @"";
                    MEDENIDURUM.CalcValue = @"";
                    COCUK.CalcValue = @"";
                    ANT.CalcValue = @"";
                    return new TTReportObject[] { ADSOYAD,NewField12211,PROTOKOLNO,NewField122211,NewField131,NewField141,NewField1221,NewField1331,NewField1341,NewField1351,NewField1361,TCID,KLINIK,CINSIYET,YAS,KILO,BOY,TANI,NewField111211,NewField111221,NewField111231,NewField111241,NewField111251,NewField111261,NewField111271,NewField111281,NewField111291,YATIS_TARIHI,YATIS_SAATI,CIKIS_TARIHI,LISAN,EGITIM,MESLEK,MEDENIDURUM,COCUK,ANT};
                }

                public override void RunScript()
                {
#region PARENT HEADER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((NursingFallingDownRiskReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            NursingApplication nursingApplication = (NursingApplication)context.GetObject(new Guid(sObjectID), "NursingApplication");
            Episode episode = nursingApplication.Episode;
            SubEpisode subepisode = nursingApplication.SubEpisode;
            Patient patient = episode.Patient;
            //HASTA BİLGİLERİ
            foreach (var item in episode.SubEpisodes)
            {
                if (item.CurrentStateDefID != SubEpisode.States.Cancelled)
                {
                    this.PROTOKOLNO.CalcValue = item.ProtocolNo;
                    //TODO
                    this.KLINIK.CalcValue = item.ResSection.GetMySKRSKlinikler().ADI;
                    break;
                }
            }
            this.ADSOYAD.CalcValue = patient.FullName;
            this.TCID.CalcValue = episode.Patient.UniqueRefNo.ToString();
            this.CINSIYET.CalcValue = episode.Patient.Sex.ADI;
            this.YAS.CalcValue = episode.Patient.Age.ToString();

            this.MESLEK.CalcValue = episode.Patient.Occupation?.ADI;
            this.EGITIM.CalcValue = episode.Patient.EducationStatus?.ADI;
            this.MEDENIDURUM.CalcValue = episode.Patient.SKRSMaritalStatus?.ADI;
            if (subepisode.InpatientAdmission != null)
            {
                this.YATIS_TARIHI.CalcValue = subepisode.InpatientAdmission.HospitalInPatientDate?.ToShortDateString();
                this.YATIS_SAATI.CalcValue = subepisode.InpatientAdmission.HospitalInPatientDate?.ToShortTimeString();
                this.CIKIS_TARIHI.CalcValue = subepisode.InpatientAdmission.HospitalDischargeDate?.ToShortDateString();
            }

            //Tıbbi Bilgiler
            this.TANI.CalcValue = "";
            int a = nursingApplication.SubEpisode.Diagnosis.Count;
            for (int i = 0; i < a; i++)
            {
                this.TANI.CalcValue = this.TANI.CalcValue + subepisode.Diagnosis[i].Diagnose.Name.ToString() + " ,";
            }
            if (nursingApplication.Temperatures.Count > 0)
            {
                this.ANT.CalcValue = "Ateş: " + nursingApplication.Temperatures.FirstOrDefault()?.Value.ToString() + " ";
            }
            if (nursingApplication.Pulses.Count > 0)
            {
                this.ANT.CalcValue = "Nabız: " + nursingApplication.Pulses.FirstOrDefault()?.Value.ToString() + " ";
            }
            if (nursingApplication.BloodPressures.Count > 0)
            {
                this.ANT.CalcValue = "Tansiyon(Diastolik): " + nursingApplication.BloodPressures.FirstOrDefault()?.Diastolik.ToString()
                    + " Tansiyon(Sistolik): " + nursingApplication.BloodPressures.FirstOrDefault()?.Sistolik.ToString();
            }
#endregion PARENT HEADER_Script
                }
            }
            public partial class PARENTGroupFooter : TTReportSection
            {
                public NursingFallingDownRiskReport MyParentReport
                {
                    get { return (NursingFallingDownRiskReport)ParentReport; }
                }
                 
                public PARENTGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 2;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARENTGroup PARENT;

        public partial class NURSINGFALLINGGroup : TTReportGroup
        {
            public NursingFallingDownRiskReport MyParentReport
            {
                get { return (NursingFallingDownRiskReport)ParentReport; }
            }

            new public NURSINGFALLINGGroupHeader Header()
            {
                return (NURSINGFALLINGGroupHeader)_header;
            }

            new public NURSINGFALLINGGroupFooter Footer()
            {
                return (NURSINGFALLINGGroupFooter)_footer;
            }

            public TTReportField DEGERLENDIRMEZAMANI1 { get {return Header().DEGERLENDIRMEZAMANI1;} }
            public TTReportField DEGERLENDIRMEZAMANI2 { get {return Header().DEGERLENDIRMEZAMANI2;} }
            public TTReportField DEGERLENDIRMEZAMANI3 { get {return Header().DEGERLENDIRMEZAMANI3;} }
            public TTReportField DEGERLENDIRMEZAMANI4 { get {return Header().DEGERLENDIRMEZAMANI4;} }
            public TTReportField NewField1112211 { get {return Header().NewField1112211;} }
            public TTReportField lblBilgi1 { get {return Header().lblBilgi1;} }
            public TTReportField lblPuan1 { get {return Header().lblPuan1;} }
            public TTReportField lblPuan112 { get {return Header().lblPuan112;} }
            public TTReportField lblBilgi12 { get {return Header().lblBilgi12;} }
            public TTReportField lblPuan123 { get {return Header().lblPuan123;} }
            public TTReportField lblBilgi13 { get {return Header().lblBilgi13;} }
            public TTReportField lblPuan134 { get {return Header().lblPuan134;} }
            public TTReportField lblBilgi11 { get {return Header().lblBilgi11;} }
            public TTReportField TOPLAMPUAN14 { get {return Header().TOPLAMPUAN14;} }
            public TTReportField TOPLAMPUAN11 { get {return Header().TOPLAMPUAN11;} }
            public TTReportField TOPLAMPUAN12 { get {return Header().TOPLAMPUAN12;} }
            public TTReportField TOPLAMPUAN13 { get {return Header().TOPLAMPUAN13;} }
            public TTReportField HEMSIRE11 { get {return Header().HEMSIRE11;} }
            public TTReportField HEMSIRE12 { get {return Header().HEMSIRE12;} }
            public TTReportField HEMSIRE13 { get {return Header().HEMSIRE13;} }
            public TTReportField NEDEN14 { get {return Header().NEDEN14;} }
            public TTReportField NEDEN11 { get {return Header().NEDEN11;} }
            public TTReportField NEDEN12 { get {return Header().NEDEN12;} }
            public TTReportField NEDEN13 { get {return Header().NEDEN13;} }
            public TTReportField HEMSIRE14 { get {return Header().HEMSIRE14;} }
            public NURSINGFALLINGGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public NURSINGFALLINGGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new NURSINGFALLINGGroupHeader(this);
                _footer = new NURSINGFALLINGGroupFooter(this);

            }

            public partial class NURSINGFALLINGGroupHeader : TTReportSection
            {
                public NursingFallingDownRiskReport MyParentReport
                {
                    get { return (NursingFallingDownRiskReport)ParentReport; }
                }
                
                public TTReportField DEGERLENDIRMEZAMANI1;
                public TTReportField DEGERLENDIRMEZAMANI2;
                public TTReportField DEGERLENDIRMEZAMANI3;
                public TTReportField DEGERLENDIRMEZAMANI4;
                public TTReportField NewField1112211;
                public TTReportField lblBilgi1;
                public TTReportField lblPuan1;
                public TTReportField lblPuan112;
                public TTReportField lblBilgi12;
                public TTReportField lblPuan123;
                public TTReportField lblBilgi13;
                public TTReportField lblPuan134;
                public TTReportField lblBilgi11;
                public TTReportField TOPLAMPUAN14;
                public TTReportField TOPLAMPUAN11;
                public TTReportField TOPLAMPUAN12;
                public TTReportField TOPLAMPUAN13;
                public TTReportField HEMSIRE11;
                public TTReportField HEMSIRE12;
                public TTReportField HEMSIRE13;
                public TTReportField NEDEN14;
                public TTReportField NEDEN11;
                public TTReportField NEDEN12;
                public TTReportField NEDEN13;
                public TTReportField HEMSIRE14; 
                public NURSINGFALLINGGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 11;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    DEGERLENDIRMEZAMANI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 1, 138, 6, false);
                    DEGERLENDIRMEZAMANI1.Name = "DEGERLENDIRMEZAMANI1";
                    DEGERLENDIRMEZAMANI1.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    DEGERLENDIRMEZAMANI1.FieldType = ReportFieldTypeEnum.ftVariable;
                    DEGERLENDIRMEZAMANI1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DEGERLENDIRMEZAMANI1.TextFont.Size = 9;
                    DEGERLENDIRMEZAMANI1.TextFont.Bold = true;
                    DEGERLENDIRMEZAMANI1.TextFont.CharSet = 162;
                    DEGERLENDIRMEZAMANI1.Value = @"";

                    DEGERLENDIRMEZAMANI2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 1, 160, 6, false);
                    DEGERLENDIRMEZAMANI2.Name = "DEGERLENDIRMEZAMANI2";
                    DEGERLENDIRMEZAMANI2.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    DEGERLENDIRMEZAMANI2.FieldType = ReportFieldTypeEnum.ftVariable;
                    DEGERLENDIRMEZAMANI2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DEGERLENDIRMEZAMANI2.TextFont.Size = 9;
                    DEGERLENDIRMEZAMANI2.TextFont.Bold = true;
                    DEGERLENDIRMEZAMANI2.TextFont.CharSet = 162;
                    DEGERLENDIRMEZAMANI2.Value = @"";

                    DEGERLENDIRMEZAMANI3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 1, 182, 6, false);
                    DEGERLENDIRMEZAMANI3.Name = "DEGERLENDIRMEZAMANI3";
                    DEGERLENDIRMEZAMANI3.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    DEGERLENDIRMEZAMANI3.FieldType = ReportFieldTypeEnum.ftVariable;
                    DEGERLENDIRMEZAMANI3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DEGERLENDIRMEZAMANI3.TextFont.Size = 9;
                    DEGERLENDIRMEZAMANI3.TextFont.Bold = true;
                    DEGERLENDIRMEZAMANI3.TextFont.CharSet = 162;
                    DEGERLENDIRMEZAMANI3.Value = @"";

                    DEGERLENDIRMEZAMANI4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 1, 204, 6, false);
                    DEGERLENDIRMEZAMANI4.Name = "DEGERLENDIRMEZAMANI4";
                    DEGERLENDIRMEZAMANI4.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    DEGERLENDIRMEZAMANI4.FieldType = ReportFieldTypeEnum.ftVariable;
                    DEGERLENDIRMEZAMANI4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DEGERLENDIRMEZAMANI4.TextFont.Size = 9;
                    DEGERLENDIRMEZAMANI4.TextFont.Bold = true;
                    DEGERLENDIRMEZAMANI4.TextFont.CharSet = 162;
                    DEGERLENDIRMEZAMANI4.Value = @"";

                    NewField1112211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 6, 116, 11, false);
                    NewField1112211.Name = "NewField1112211";
                    NewField1112211.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    NewField1112211.TextFont.Bold = true;
                    NewField1112211.TextFont.CharSet = 162;
                    NewField1112211.Value = @"Risk Faktörü";

                    lblBilgi1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 6, 127, 11, false);
                    lblBilgi1.Name = "lblBilgi1";
                    lblBilgi1.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    lblBilgi1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    lblBilgi1.TextFont.Bold = true;
                    lblBilgi1.TextFont.CharSet = 162;
                    lblBilgi1.Value = @"Bilgi";

                    lblPuan1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 6, 138, 11, false);
                    lblPuan1.Name = "lblPuan1";
                    lblPuan1.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    lblPuan1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    lblPuan1.TextFont.Bold = true;
                    lblPuan1.TextFont.CharSet = 162;
                    lblPuan1.Value = @"Puan";

                    lblPuan112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 6, 160, 11, false);
                    lblPuan112.Name = "lblPuan112";
                    lblPuan112.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    lblPuan112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    lblPuan112.TextFont.Bold = true;
                    lblPuan112.TextFont.CharSet = 162;
                    lblPuan112.Value = @"Puan";

                    lblBilgi12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 6, 171, 11, false);
                    lblBilgi12.Name = "lblBilgi12";
                    lblBilgi12.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    lblBilgi12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    lblBilgi12.TextFont.Bold = true;
                    lblBilgi12.TextFont.CharSet = 162;
                    lblBilgi12.Value = @"Bilgi";

                    lblPuan123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 6, 182, 11, false);
                    lblPuan123.Name = "lblPuan123";
                    lblPuan123.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    lblPuan123.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    lblPuan123.TextFont.Bold = true;
                    lblPuan123.TextFont.CharSet = 162;
                    lblPuan123.Value = @"Puan";

                    lblBilgi13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 6, 193, 11, false);
                    lblBilgi13.Name = "lblBilgi13";
                    lblBilgi13.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    lblBilgi13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    lblBilgi13.TextFont.Bold = true;
                    lblBilgi13.TextFont.CharSet = 162;
                    lblBilgi13.Value = @"Bilgi";

                    lblPuan134 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 193, 6, 204, 11, false);
                    lblPuan134.Name = "lblPuan134";
                    lblPuan134.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    lblPuan134.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    lblPuan134.TextFont.Bold = true;
                    lblPuan134.TextFont.CharSet = 162;
                    lblPuan134.Value = @"Puan";

                    lblBilgi11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 6, 149, 11, false);
                    lblBilgi11.Name = "lblBilgi11";
                    lblBilgi11.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    lblBilgi11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    lblBilgi11.TextFont.Bold = true;
                    lblBilgi11.TextFont.CharSet = 162;
                    lblBilgi11.Value = @"Bilgi";

                    TOPLAMPUAN14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 294, 3, 316, 7, false);
                    TOPLAMPUAN14.Name = "TOPLAMPUAN14";
                    TOPLAMPUAN14.Visible = EvetHayirEnum.ehHayir;
                    TOPLAMPUAN14.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    TOPLAMPUAN14.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOPLAMPUAN14.TextFont.Size = 9;
                    TOPLAMPUAN14.TextFont.CharSet = 162;
                    TOPLAMPUAN14.Value = @"";

                    TOPLAMPUAN11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 228, 3, 250, 7, false);
                    TOPLAMPUAN11.Name = "TOPLAMPUAN11";
                    TOPLAMPUAN11.Visible = EvetHayirEnum.ehHayir;
                    TOPLAMPUAN11.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    TOPLAMPUAN11.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOPLAMPUAN11.TextFont.Size = 9;
                    TOPLAMPUAN11.TextFont.CharSet = 162;
                    TOPLAMPUAN11.Value = @"";

                    TOPLAMPUAN12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 250, 3, 272, 7, false);
                    TOPLAMPUAN12.Name = "TOPLAMPUAN12";
                    TOPLAMPUAN12.Visible = EvetHayirEnum.ehHayir;
                    TOPLAMPUAN12.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    TOPLAMPUAN12.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOPLAMPUAN12.TextFont.Size = 9;
                    TOPLAMPUAN12.TextFont.CharSet = 162;
                    TOPLAMPUAN12.Value = @"";

                    TOPLAMPUAN13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 272, 3, 294, 7, false);
                    TOPLAMPUAN13.Name = "TOPLAMPUAN13";
                    TOPLAMPUAN13.Visible = EvetHayirEnum.ehHayir;
                    TOPLAMPUAN13.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    TOPLAMPUAN13.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOPLAMPUAN13.TextFont.Size = 9;
                    TOPLAMPUAN13.TextFont.CharSet = 162;
                    TOPLAMPUAN13.Value = @"";

                    HEMSIRE11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 228, 12, 250, 22, false);
                    HEMSIRE11.Name = "HEMSIRE11";
                    HEMSIRE11.Visible = EvetHayirEnum.ehHayir;
                    HEMSIRE11.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    HEMSIRE11.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEMSIRE11.MultiLine = EvetHayirEnum.ehEvet;
                    HEMSIRE11.NoClip = EvetHayirEnum.ehEvet;
                    HEMSIRE11.WordBreak = EvetHayirEnum.ehEvet;
                    HEMSIRE11.ExpandTabs = EvetHayirEnum.ehEvet;
                    HEMSIRE11.TextFont.CharSet = 162;
                    HEMSIRE11.Value = @"";

                    HEMSIRE12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 250, 12, 272, 22, false);
                    HEMSIRE12.Name = "HEMSIRE12";
                    HEMSIRE12.Visible = EvetHayirEnum.ehHayir;
                    HEMSIRE12.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    HEMSIRE12.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEMSIRE12.MultiLine = EvetHayirEnum.ehEvet;
                    HEMSIRE12.NoClip = EvetHayirEnum.ehEvet;
                    HEMSIRE12.WordBreak = EvetHayirEnum.ehEvet;
                    HEMSIRE12.ExpandTabs = EvetHayirEnum.ehEvet;
                    HEMSIRE12.TextFont.CharSet = 162;
                    HEMSIRE12.Value = @"";

                    HEMSIRE13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 272, 12, 294, 22, false);
                    HEMSIRE13.Name = "HEMSIRE13";
                    HEMSIRE13.Visible = EvetHayirEnum.ehHayir;
                    HEMSIRE13.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    HEMSIRE13.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEMSIRE13.MultiLine = EvetHayirEnum.ehEvet;
                    HEMSIRE13.NoClip = EvetHayirEnum.ehEvet;
                    HEMSIRE13.WordBreak = EvetHayirEnum.ehEvet;
                    HEMSIRE13.ExpandTabs = EvetHayirEnum.ehEvet;
                    HEMSIRE13.TextFont.CharSet = 162;
                    HEMSIRE13.Value = @"";

                    NEDEN14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 294, 7, 316, 12, false);
                    NEDEN14.Name = "NEDEN14";
                    NEDEN14.Visible = EvetHayirEnum.ehHayir;
                    NEDEN14.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    NEDEN14.FieldType = ReportFieldTypeEnum.ftVariable;
                    NEDEN14.TextFont.CharSet = 162;
                    NEDEN14.Value = @"";

                    NEDEN11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 228, 7, 250, 12, false);
                    NEDEN11.Name = "NEDEN11";
                    NEDEN11.Visible = EvetHayirEnum.ehHayir;
                    NEDEN11.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    NEDEN11.FieldType = ReportFieldTypeEnum.ftVariable;
                    NEDEN11.TextFont.CharSet = 162;
                    NEDEN11.Value = @"";

                    NEDEN12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 250, 7, 272, 12, false);
                    NEDEN12.Name = "NEDEN12";
                    NEDEN12.Visible = EvetHayirEnum.ehHayir;
                    NEDEN12.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    NEDEN12.FieldType = ReportFieldTypeEnum.ftVariable;
                    NEDEN12.TextFont.CharSet = 162;
                    NEDEN12.Value = @"";

                    NEDEN13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 272, 7, 294, 12, false);
                    NEDEN13.Name = "NEDEN13";
                    NEDEN13.Visible = EvetHayirEnum.ehHayir;
                    NEDEN13.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    NEDEN13.FieldType = ReportFieldTypeEnum.ftVariable;
                    NEDEN13.TextFont.CharSet = 162;
                    NEDEN13.Value = @"";

                    HEMSIRE14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 294, 12, 316, 22, false);
                    HEMSIRE14.Name = "HEMSIRE14";
                    HEMSIRE14.Visible = EvetHayirEnum.ehHayir;
                    HEMSIRE14.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    HEMSIRE14.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEMSIRE14.MultiLine = EvetHayirEnum.ehEvet;
                    HEMSIRE14.NoClip = EvetHayirEnum.ehEvet;
                    HEMSIRE14.WordBreak = EvetHayirEnum.ehEvet;
                    HEMSIRE14.ExpandTabs = EvetHayirEnum.ehEvet;
                    HEMSIRE14.TextFont.CharSet = 162;
                    HEMSIRE14.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DEGERLENDIRMEZAMANI1.CalcValue = @"";
                    DEGERLENDIRMEZAMANI2.CalcValue = @"";
                    DEGERLENDIRMEZAMANI3.CalcValue = @"";
                    DEGERLENDIRMEZAMANI4.CalcValue = @"";
                    NewField1112211.CalcValue = NewField1112211.Value;
                    lblBilgi1.CalcValue = lblBilgi1.Value;
                    lblPuan1.CalcValue = lblPuan1.Value;
                    lblPuan112.CalcValue = lblPuan112.Value;
                    lblBilgi12.CalcValue = lblBilgi12.Value;
                    lblPuan123.CalcValue = lblPuan123.Value;
                    lblBilgi13.CalcValue = lblBilgi13.Value;
                    lblPuan134.CalcValue = lblPuan134.Value;
                    lblBilgi11.CalcValue = lblBilgi11.Value;
                    TOPLAMPUAN14.CalcValue = @"";
                    TOPLAMPUAN11.CalcValue = @"";
                    TOPLAMPUAN12.CalcValue = @"";
                    TOPLAMPUAN13.CalcValue = @"";
                    HEMSIRE11.CalcValue = @"";
                    HEMSIRE12.CalcValue = @"";
                    HEMSIRE13.CalcValue = @"";
                    NEDEN14.CalcValue = @"";
                    NEDEN11.CalcValue = @"";
                    NEDEN12.CalcValue = @"";
                    NEDEN13.CalcValue = @"";
                    HEMSIRE14.CalcValue = @"";
                    return new TTReportObject[] { DEGERLENDIRMEZAMANI1,DEGERLENDIRMEZAMANI2,DEGERLENDIRMEZAMANI3,DEGERLENDIRMEZAMANI4,NewField1112211,lblBilgi1,lblPuan1,lblPuan112,lblBilgi12,lblPuan123,lblBilgi13,lblPuan134,lblBilgi11,TOPLAMPUAN14,TOPLAMPUAN11,TOPLAMPUAN12,TOPLAMPUAN13,HEMSIRE11,HEMSIRE12,HEMSIRE13,NEDEN14,NEDEN11,NEDEN12,NEDEN13,HEMSIRE14};
                }

                public override void RunScript()
                {
#region NURSINGFALLING HEADER_Script
                    if (MyParentReport.NURSINGFALLING.RepeatCount > 0)
            {
                MyParentReport.tempDetailObjectIndexList = new List<int>();
                MyParentReport.mainCounter = 0;
                List<FunctionDetail> functionDetailList = MyParentReport.functionDetailList;
                var func = functionDetailList[0];
                int i = 1;
                while(MyParentReport.detailObjectCounter < MyParentReport.mainCounterVertical && i<=4)
                {
                    var obj = func.detailObjectList[MyParentReport.detailObjectCounter];
                    MyParentReport.tempDetailObjectIndexList.Add(MyParentReport.detailObjectCounter);
                    if(i == 1)
                    {
                        this.DEGERLENDIRMEZAMANI1.CalcValue = obj.TARIH;
                        this.TOPLAMPUAN11.CalcValue = obj.TOTALSCORE.ToString();
                        this.NEDEN11.CalcValue = obj.NEDEN;
                        this.HEMSIRE11.CalcValue = obj.HEMSIRE;
                    }
                    else if(i == 2)
                    {
                        this.DEGERLENDIRMEZAMANI2.CalcValue = obj.TARIH;
                        this.TOPLAMPUAN12.CalcValue = obj.TOTALSCORE.ToString();
                        this.NEDEN12.CalcValue = obj.NEDEN;
                        this.HEMSIRE12.CalcValue = obj.HEMSIRE;
                    }
                    else if(i == 3)
                    {
                        this.DEGERLENDIRMEZAMANI3.CalcValue = obj.TARIH;
                        this.TOPLAMPUAN13.CalcValue = obj.TOTALSCORE.ToString();
                        this.NEDEN13.CalcValue = obj.NEDEN;
                        this.HEMSIRE13.CalcValue = obj.HEMSIRE;
                    }
                    else if(i == 4)
                    {
                        this.DEGERLENDIRMEZAMANI4.CalcValue = obj.TARIH;
                        this.TOPLAMPUAN14.CalcValue = obj.TOTALSCORE.ToString();
                        this.NEDEN14.CalcValue = obj.NEDEN;
                        this.HEMSIRE14.CalcValue = obj.HEMSIRE;
                    }
                    this.Visible = EvetHayirEnum.ehEvet;
                    MyParentReport.detailObjectCounter += 1;
                    i++;//4 e ulaştığında döngüden çıkacak. Çünkü her seferinde sadece 4 tarih için çalışıyor.
                }
            }
            else
            {
                this.Visible = EvetHayirEnum.ehHayir;
            }
#endregion NURSINGFALLING HEADER_Script
                }
            }
            public partial class NURSINGFALLINGGroupFooter : TTReportSection
            {
                public NursingFallingDownRiskReport MyParentReport
                {
                    get { return (NursingFallingDownRiskReport)ParentReport; }
                }
                 
                public NURSINGFALLINGGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 3;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public NURSINGFALLINGGroup NURSINGFALLING;

        public partial class MAINGroup : TTReportGroup
        {
            public NursingFallingDownRiskReport MyParentReport
            {
                get { return (NursingFallingDownRiskReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField LABEL { get {return Body().LABEL;} }
            public TTReportField BILGI1 { get {return Body().BILGI1;} }
            public TTReportField PUAN1 { get {return Body().PUAN1;} }
            public TTReportField BILGI2 { get {return Body().BILGI2;} }
            public TTReportField PUAN2 { get {return Body().PUAN2;} }
            public TTReportField BILGI3 { get {return Body().BILGI3;} }
            public TTReportField PUAN3 { get {return Body().PUAN3;} }
            public TTReportField BILGI4 { get {return Body().BILGI4;} }
            public TTReportField PUAN4 { get {return Body().PUAN4;} }
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
                public NursingFallingDownRiskReport MyParentReport
                {
                    get { return (NursingFallingDownRiskReport)ParentReport; }
                }
                
                public TTReportField LABEL;
                public TTReportField BILGI1;
                public TTReportField PUAN1;
                public TTReportField BILGI2;
                public TTReportField PUAN2;
                public TTReportField BILGI3;
                public TTReportField PUAN3;
                public TTReportField BILGI4;
                public TTReportField PUAN4; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    LABEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 0, 116, 5, false);
                    LABEL.Name = "LABEL";
                    LABEL.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    LABEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    LABEL.TextFont.Size = 9;
                    LABEL.TextFont.Bold = true;
                    LABEL.TextFont.CharSet = 162;
                    LABEL.Value = @"";

                    BILGI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 0, 127, 5, false);
                    BILGI1.Name = "BILGI1";
                    BILGI1.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    BILGI1.FieldType = ReportFieldTypeEnum.ftVariable;
                    BILGI1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BILGI1.TextFont.Size = 9;
                    BILGI1.TextFont.CharSet = 162;
                    BILGI1.Value = @"";

                    PUAN1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 0, 138, 5, false);
                    PUAN1.Name = "PUAN1";
                    PUAN1.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    PUAN1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PUAN1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PUAN1.TextFont.Size = 9;
                    PUAN1.TextFont.CharSet = 162;
                    PUAN1.Value = @"";

                    BILGI2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 0, 149, 5, false);
                    BILGI2.Name = "BILGI2";
                    BILGI2.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    BILGI2.FieldType = ReportFieldTypeEnum.ftVariable;
                    BILGI2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BILGI2.TextFont.Size = 9;
                    BILGI2.TextFont.CharSet = 162;
                    BILGI2.Value = @"";

                    PUAN2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 0, 160, 5, false);
                    PUAN2.Name = "PUAN2";
                    PUAN2.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    PUAN2.FieldType = ReportFieldTypeEnum.ftVariable;
                    PUAN2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PUAN2.TextFont.Size = 9;
                    PUAN2.TextFont.CharSet = 162;
                    PUAN2.Value = @"";

                    BILGI3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 0, 171, 5, false);
                    BILGI3.Name = "BILGI3";
                    BILGI3.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    BILGI3.FieldType = ReportFieldTypeEnum.ftVariable;
                    BILGI3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BILGI3.TextFont.Size = 9;
                    BILGI3.TextFont.CharSet = 162;
                    BILGI3.Value = @"";

                    PUAN3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 0, 182, 5, false);
                    PUAN3.Name = "PUAN3";
                    PUAN3.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    PUAN3.FieldType = ReportFieldTypeEnum.ftVariable;
                    PUAN3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PUAN3.TextFont.Size = 9;
                    PUAN3.TextFont.CharSet = 162;
                    PUAN3.Value = @"";

                    BILGI4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 0, 193, 5, false);
                    BILGI4.Name = "BILGI4";
                    BILGI4.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    BILGI4.FieldType = ReportFieldTypeEnum.ftVariable;
                    BILGI4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BILGI4.TextFont.Size = 9;
                    BILGI4.TextFont.CharSet = 162;
                    BILGI4.Value = @"";

                    PUAN4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 193, 0, 204, 5, false);
                    PUAN4.Name = "PUAN4";
                    PUAN4.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    PUAN4.FieldType = ReportFieldTypeEnum.ftVariable;
                    PUAN4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PUAN4.TextFont.Size = 9;
                    PUAN4.TextFont.CharSet = 162;
                    PUAN4.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LABEL.CalcValue = @"";
                    BILGI1.CalcValue = @"";
                    PUAN1.CalcValue = @"";
                    BILGI2.CalcValue = @"";
                    PUAN2.CalcValue = @"";
                    BILGI3.CalcValue = @"";
                    PUAN3.CalcValue = @"";
                    BILGI4.CalcValue = @"";
                    PUAN4.CalcValue = @"";
                    return new TTReportObject[] { LABEL,BILGI1,PUAN1,BILGI2,PUAN2,BILGI3,PUAN3,BILGI4,PUAN4};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if (MyParentReport.MAIN.RepeatCount > 0)
            {
                this.BILGI1.CalcValue = "";
                this.PUAN1.CalcValue = "";
                this.BILGI2.CalcValue = "";
                this.PUAN2.CalcValue = "";
                this.BILGI3.CalcValue = "";
                this.PUAN3.CalcValue = "";
                this.BILGI4.CalcValue = "";
                this.PUAN4.CalcValue = "";
                List<FunctionDetail> functionDetailList = MyParentReport.functionDetailList;
                var func = functionDetailList[MyParentReport.mainCounter];
                int i = 1;
                int totalScore = 0;
                int tempDetailObjIndexCount = MyParentReport.tempDetailObjectIndexList.Count;
                while(MyParentReport.detailObjectMainBodyCounter < tempDetailObjIndexCount && i<=4)
                {

                    var obj = func.detailObjectList[MyParentReport.tempDetailObjectIndexList[MyParentReport.detailObjectMainBodyCounter]];
                    if(i == 1)
                    {
                        this.BILGI1.CalcValue = obj.BILGI;
                        this.PUAN1.CalcValue = obj.PUAN;
                    }
                    
                    else if(i == 2)
                    {
                        this.BILGI2.CalcValue = obj.BILGI;
                        this.PUAN2.CalcValue = obj.PUAN;
                    }
                    
                    else if(i == 3)
                    {
                        this.BILGI3.CalcValue = obj.BILGI;
                        this.PUAN3.CalcValue = obj.PUAN;
                    }
                    else if(i == 4)
                    {
                        this.BILGI4.CalcValue = obj.BILGI;
                        this.PUAN4.CalcValue = obj.PUAN;
                    }
                    MyParentReport.detailObjectMainBodyCounter += 1;
                    i++;//4 e ulaştığında döngüden çıkacak. Çünkü her seferinde sadece 4 tarih için çalışıyor.
                }
                this.Visible = EvetHayirEnum.ehEvet;
                MyParentReport.mainCounter += 1;
                this.LABEL.CalcValue = func.functionName;
                MyParentReport.detailObjectMainBodyCounter = 0;
            }
            else
            {
                this.Visible = EvetHayirEnum.ehHayir;
            }
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class MAINSIBLINGGroup : TTReportGroup
        {
            public NursingFallingDownRiskReport MyParentReport
            {
                get { return (NursingFallingDownRiskReport)ParentReport; }
            }

            new public MAINSIBLINGGroupBody Body()
            {
                return (MAINSIBLINGGroupBody)_body;
            }
            public TTReportField TOTAL11 { get {return Body().TOTAL11;} }
            public TTReportField TOPLAMPUAN14 { get {return Body().TOPLAMPUAN14;} }
            public TTReportField NewField111 { get {return Body().NewField111;} }
            public TTReportField TOPLAMPUAN11 { get {return Body().TOPLAMPUAN11;} }
            public TTReportField TOPLAMPUAN12 { get {return Body().TOPLAMPUAN12;} }
            public TTReportField TOPLAMPUAN13 { get {return Body().TOPLAMPUAN13;} }
            public TTReportField HEMSIRE11 { get {return Body().HEMSIRE11;} }
            public TTReportField HEMSIRE12 { get {return Body().HEMSIRE12;} }
            public TTReportField HEMSIRE13 { get {return Body().HEMSIRE13;} }
            public TTReportField NewField1111 { get {return Body().NewField1111;} }
            public TTReportField HEMSIRE1411 { get {return Body().HEMSIRE1411;} }
            public TTReportField HEMSIRE1111 { get {return Body().HEMSIRE1111;} }
            public TTReportField HEMSIRE1121 { get {return Body().HEMSIRE1121;} }
            public TTReportField HEMSIRE1131 { get {return Body().HEMSIRE1131;} }
            public TTReportField NewField1131 { get {return Body().NewField1131;} }
            public TTReportField NEDEN14 { get {return Body().NEDEN14;} }
            public TTReportField NEDEN11 { get {return Body().NEDEN11;} }
            public TTReportField NEDEN12 { get {return Body().NEDEN12;} }
            public TTReportField NEDEN13 { get {return Body().NEDEN13;} }
            public TTReportField HEMSIRE14 { get {return Body().HEMSIRE14;} }
            public MAINSIBLINGGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINSIBLINGGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINSIBLINGGroupBody(this);
            }

            public partial class MAINSIBLINGGroupBody : TTReportSection
            {
                public NursingFallingDownRiskReport MyParentReport
                {
                    get { return (NursingFallingDownRiskReport)ParentReport; }
                }
                
                public TTReportField TOTAL11;
                public TTReportField TOPLAMPUAN14;
                public TTReportField NewField111;
                public TTReportField TOPLAMPUAN11;
                public TTReportField TOPLAMPUAN12;
                public TTReportField TOPLAMPUAN13;
                public TTReportField HEMSIRE11;
                public TTReportField HEMSIRE12;
                public TTReportField HEMSIRE13;
                public TTReportField NewField1111;
                public TTReportField HEMSIRE1411;
                public TTReportField HEMSIRE1111;
                public TTReportField HEMSIRE1121;
                public TTReportField HEMSIRE1131;
                public TTReportField NewField1131;
                public TTReportField NEDEN14;
                public TTReportField NEDEN11;
                public TTReportField NEDEN12;
                public TTReportField NEDEN13;
                public TTReportField HEMSIRE14; 
                public MAINSIBLINGGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 40;
                    RepeatCount = 0;
                    
                    TOTAL11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 0, 116, 5, false);
                    TOTAL11.Name = "TOTAL11";
                    TOTAL11.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    TOTAL11.TextFont.Size = 9;
                    TOTAL11.TextFont.Bold = true;
                    TOTAL11.TextFont.CharSet = 162;
                    TOTAL11.Value = @"TOPLAM PUAN";

                    TOPLAMPUAN14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 0, 204, 5, false);
                    TOPLAMPUAN14.Name = "TOPLAMPUAN14";
                    TOPLAMPUAN14.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    TOPLAMPUAN14.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOPLAMPUAN14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOPLAMPUAN14.TextFont.Size = 9;
                    TOPLAMPUAN14.TextFont.CharSet = 162;
                    TOPLAMPUAN14.Value = @"{%NURSINGFALLING.TOPLAMPUAN14%}";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 20, 116, 30, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"Değerlendirmeyi Yapan Hemşire";

                    TOPLAMPUAN11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 0, 138, 5, false);
                    TOPLAMPUAN11.Name = "TOPLAMPUAN11";
                    TOPLAMPUAN11.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    TOPLAMPUAN11.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOPLAMPUAN11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOPLAMPUAN11.TextFont.Size = 9;
                    TOPLAMPUAN11.TextFont.CharSet = 162;
                    TOPLAMPUAN11.Value = @"{%NURSINGFALLING.TOPLAMPUAN11%}";

                    TOPLAMPUAN12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 0, 160, 5, false);
                    TOPLAMPUAN12.Name = "TOPLAMPUAN12";
                    TOPLAMPUAN12.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    TOPLAMPUAN12.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOPLAMPUAN12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOPLAMPUAN12.TextFont.Size = 9;
                    TOPLAMPUAN12.TextFont.CharSet = 162;
                    TOPLAMPUAN12.Value = @"{%NURSINGFALLING.TOPLAMPUAN12%}";

                    TOPLAMPUAN13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 0, 182, 5, false);
                    TOPLAMPUAN13.Name = "TOPLAMPUAN13";
                    TOPLAMPUAN13.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    TOPLAMPUAN13.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOPLAMPUAN13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOPLAMPUAN13.TextFont.Size = 9;
                    TOPLAMPUAN13.TextFont.CharSet = 162;
                    TOPLAMPUAN13.Value = @"{%NURSINGFALLING.TOPLAMPUAN13%}";

                    HEMSIRE11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 20, 138, 30, false);
                    HEMSIRE11.Name = "HEMSIRE11";
                    HEMSIRE11.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    HEMSIRE11.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEMSIRE11.MultiLine = EvetHayirEnum.ehEvet;
                    HEMSIRE11.WordBreak = EvetHayirEnum.ehEvet;
                    HEMSIRE11.TextFont.CharSet = 162;
                    HEMSIRE11.Value = @"{%NURSINGFALLING.HEMSIRE11%}";

                    HEMSIRE12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 20, 160, 30, false);
                    HEMSIRE12.Name = "HEMSIRE12";
                    HEMSIRE12.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    HEMSIRE12.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEMSIRE12.MultiLine = EvetHayirEnum.ehEvet;
                    HEMSIRE12.WordBreak = EvetHayirEnum.ehEvet;
                    HEMSIRE12.TextFont.CharSet = 162;
                    HEMSIRE12.Value = @"{%NURSINGFALLING.HEMSIRE12%}";

                    HEMSIRE13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 20, 182, 30, false);
                    HEMSIRE13.Name = "HEMSIRE13";
                    HEMSIRE13.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    HEMSIRE13.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEMSIRE13.MultiLine = EvetHayirEnum.ehEvet;
                    HEMSIRE13.WordBreak = EvetHayirEnum.ehEvet;
                    HEMSIRE13.TextFont.CharSet = 162;
                    HEMSIRE13.Value = @"{%NURSINGFALLING.HEMSIRE13%}";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 30, 116, 40, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"İmza";

                    HEMSIRE1411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 30, 138, 40, false);
                    HEMSIRE1411.Name = "HEMSIRE1411";
                    HEMSIRE1411.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    HEMSIRE1411.TextFont.CharSet = 162;
                    HEMSIRE1411.Value = @"";

                    HEMSIRE1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 30, 160, 40, false);
                    HEMSIRE1111.Name = "HEMSIRE1111";
                    HEMSIRE1111.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    HEMSIRE1111.TextFont.CharSet = 162;
                    HEMSIRE1111.Value = @"";

                    HEMSIRE1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 30, 182, 40, false);
                    HEMSIRE1121.Name = "HEMSIRE1121";
                    HEMSIRE1121.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    HEMSIRE1121.TextFont.CharSet = 162;
                    HEMSIRE1121.Value = @"";

                    HEMSIRE1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 30, 204, 40, false);
                    HEMSIRE1131.Name = "HEMSIRE1131";
                    HEMSIRE1131.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    HEMSIRE1131.TextFont.CharSet = 162;
                    HEMSIRE1131.Value = @"";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 5, 116, 20, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    NewField1131.TextFont.Bold = true;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @"Düşme Riski Doldurma Nedeni";

                    NEDEN14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 5, 204, 20, false);
                    NEDEN14.Name = "NEDEN14";
                    NEDEN14.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    NEDEN14.FieldType = ReportFieldTypeEnum.ftVariable;
                    NEDEN14.TextFont.CharSet = 162;
                    NEDEN14.Value = @"{%NURSINGFALLING.NEDEN14%}";

                    NEDEN11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 5, 138, 20, false);
                    NEDEN11.Name = "NEDEN11";
                    NEDEN11.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    NEDEN11.FieldType = ReportFieldTypeEnum.ftVariable;
                    NEDEN11.TextFont.CharSet = 162;
                    NEDEN11.Value = @"{%NURSINGFALLING.NEDEN11%}";

                    NEDEN12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 5, 160, 20, false);
                    NEDEN12.Name = "NEDEN12";
                    NEDEN12.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    NEDEN12.FieldType = ReportFieldTypeEnum.ftVariable;
                    NEDEN12.TextFont.CharSet = 162;
                    NEDEN12.Value = @"{%NURSINGFALLING.NEDEN12%}";

                    NEDEN13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 5, 182, 20, false);
                    NEDEN13.Name = "NEDEN13";
                    NEDEN13.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    NEDEN13.FieldType = ReportFieldTypeEnum.ftVariable;
                    NEDEN13.TextFont.CharSet = 162;
                    NEDEN13.Value = @"{%NURSINGFALLING.NEDEN13%}";

                    HEMSIRE14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 20, 204, 30, false);
                    HEMSIRE14.Name = "HEMSIRE14";
                    HEMSIRE14.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    HEMSIRE14.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEMSIRE14.MultiLine = EvetHayirEnum.ehEvet;
                    HEMSIRE14.WordBreak = EvetHayirEnum.ehEvet;
                    HEMSIRE14.TextFont.CharSet = 162;
                    HEMSIRE14.Value = @"{%NURSINGFALLING.HEMSIRE14%}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    TOTAL11.CalcValue = TOTAL11.Value;
                    TOPLAMPUAN14.CalcValue = MyParentReport.NURSINGFALLING.TOPLAMPUAN14.CalcValue;
                    NewField111.CalcValue = NewField111.Value;
                    TOPLAMPUAN11.CalcValue = MyParentReport.NURSINGFALLING.TOPLAMPUAN11.CalcValue;
                    TOPLAMPUAN12.CalcValue = MyParentReport.NURSINGFALLING.TOPLAMPUAN12.CalcValue;
                    TOPLAMPUAN13.CalcValue = MyParentReport.NURSINGFALLING.TOPLAMPUAN13.CalcValue;
                    HEMSIRE11.CalcValue = MyParentReport.NURSINGFALLING.HEMSIRE11.CalcValue;
                    HEMSIRE12.CalcValue = MyParentReport.NURSINGFALLING.HEMSIRE12.CalcValue;
                    HEMSIRE13.CalcValue = MyParentReport.NURSINGFALLING.HEMSIRE13.CalcValue;
                    NewField1111.CalcValue = NewField1111.Value;
                    HEMSIRE1411.CalcValue = HEMSIRE1411.Value;
                    HEMSIRE1111.CalcValue = HEMSIRE1111.Value;
                    HEMSIRE1121.CalcValue = HEMSIRE1121.Value;
                    HEMSIRE1131.CalcValue = HEMSIRE1131.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    NEDEN14.CalcValue = MyParentReport.NURSINGFALLING.NEDEN14.CalcValue;
                    NEDEN11.CalcValue = MyParentReport.NURSINGFALLING.NEDEN11.CalcValue;
                    NEDEN12.CalcValue = MyParentReport.NURSINGFALLING.NEDEN12.CalcValue;
                    NEDEN13.CalcValue = MyParentReport.NURSINGFALLING.NEDEN13.CalcValue;
                    HEMSIRE14.CalcValue = MyParentReport.NURSINGFALLING.HEMSIRE14.CalcValue;
                    return new TTReportObject[] { TOTAL11,TOPLAMPUAN14,NewField111,TOPLAMPUAN11,TOPLAMPUAN12,TOPLAMPUAN13,HEMSIRE11,HEMSIRE12,HEMSIRE13,NewField1111,HEMSIRE1411,HEMSIRE1111,HEMSIRE1121,HEMSIRE1131,NewField1131,NEDEN14,NEDEN11,NEDEN12,NEDEN13,HEMSIRE14};
                }
            }

        }

        public MAINSIBLINGGroup MAINSIBLING;

        public partial class BILGILENDIRMEGroup : TTReportGroup
        {
            public NursingFallingDownRiskReport MyParentReport
            {
                get { return (NursingFallingDownRiskReport)ParentReport; }
            }

            new public BILGILENDIRMEGroupBody Body()
            {
                return (BILGILENDIRMEGroupBody)_body;
            }
            public BILGILENDIRMEGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public BILGILENDIRMEGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new BILGILENDIRMEGroupBody(this);
            }

            public partial class BILGILENDIRMEGroupBody : TTReportSection
            {
                public NursingFallingDownRiskReport MyParentReport
                {
                    get { return (NursingFallingDownRiskReport)ParentReport; }
                }
                 
                public BILGILENDIRMEGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 3;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public BILGILENDIRMEGroup BILGILENDIRME;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public NursingFallingDownRiskReport()
        {
            ANA = new ANAGroup(this,"ANA");
            HEADER = new HEADERGroup(ANA,"HEADER");
            PARENT = new PARENTGroup(HEADER,"PARENT");
            NURSINGFALLING = new NURSINGFALLINGGroup(PARENT,"NURSINGFALLING");
            MAIN = new MAINGroup(NURSINGFALLING,"MAIN");
            MAINSIBLING = new MAINSIBLINGGroup(NURSINGFALLING,"MAINSIBLING");
            BILGILENDIRME = new BILGILENDIRMEGroup(HEADER,"BILGILENDIRME");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Hemşirelik İşlemi", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "NURSINGFALLINGDOWNRISKREPORT";
            Caption = "Düşme Riski Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oePortrait;
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
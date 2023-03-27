
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
    /// Reçete İstatistiği (Gruplu)
    /// </summary>
    public partial class PrescriptionStatisticWithGroupReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public PrescriptionTypeEnum? PRESCRIPTIONTYPE = (PrescriptionTypeEnum?)(int?)TTObjectDefManager.Instance.DataTypes["PrescriptionTypeEnum"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public PrescriptionStatisticWithGroupReport MyParentReport
            {
                get { return (PrescriptionStatisticWithGroupReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField ReportName { get {return Header().ReportName;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField112 { get {return Header().NewField112;} }
            public TTReportField NewField1211 { get {return Header().NewField1211;} }
            public TTReportField NewField1212 { get {return Header().NewField1212;} }
            public TTReportField StartDate { get {return Header().StartDate;} }
            public TTReportField EndDate { get {return Header().EndDate;} }
            public TTReportField PrescriptionType { get {return Header().PrescriptionType;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportField CurrentUser { get {return Footer().CurrentUser;} }
            public TTReportShape NewLine111 { get {return Footer().NewLine111;} }
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
                public PrescriptionStatisticWithGroupReport MyParentReport
                {
                    get { return (PrescriptionStatisticWithGroupReport)ParentReport; }
                }
                
                public TTReportField LOGO;
                public TTReportField ReportName;
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField111;
                public TTReportField NewField112;
                public TTReportField NewField1211;
                public TTReportField NewField1212;
                public TTReportField StartDate;
                public TTReportField EndDate;
                public TTReportField PrescriptionType; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 41;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 40, 20, false);
                    LOGO.Name = "LOGO";
                    LOGO.Value = @"";

                    ReportName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 0, 257, 20, false);
                    ReportName.Name = "ReportName";
                    ReportName.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName.TextFont.Size = 15;
                    ReportName.TextFont.Bold = true;
                    ReportName.TextFont.CharSet = 162;
                    ReportName.Value = @"REÇETE İSTATİSTİĞİ (GRUPLU)";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 24, 23, 29, false);
                    NewField1.Name = "NewField1";
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Başlangıç Tarihi";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 29, 23, 34, false);
                    NewField11.Name = "NewField11";
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Bitiş Tarihi";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 34, 23, 39, false);
                    NewField111.Name = "NewField111";
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"Reçete Türü";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 24, 24, 29, false);
                    NewField112.Name = "NewField112";
                    NewField112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112.TextFont.Bold = true;
                    NewField112.TextFont.CharSet = 162;
                    NewField112.Value = @":";

                    NewField1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 29, 24, 34, false);
                    NewField1211.Name = "NewField1211";
                    NewField1211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1211.TextFont.Bold = true;
                    NewField1211.TextFont.CharSet = 162;
                    NewField1211.Value = @":";

                    NewField1212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 34, 24, 39, false);
                    NewField1212.Name = "NewField1212";
                    NewField1212.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1212.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1212.TextFont.Bold = true;
                    NewField1212.TextFont.CharSet = 162;
                    NewField1212.Value = @":";

                    StartDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 24, 49, 29, false);
                    StartDate.Name = "StartDate";
                    StartDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    StartDate.TextFormat = @"dd/MM/yyyy";
                    StartDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    StartDate.Value = @"{@STARTDATE@}";

                    EndDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 29, 49, 34, false);
                    EndDate.Name = "EndDate";
                    EndDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    EndDate.TextFormat = @"dd/MM/yyyy";
                    EndDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EndDate.Value = @"{@ENDDATE@}";

                    PrescriptionType = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 34, 49, 39, false);
                    PrescriptionType.Name = "PrescriptionType";
                    PrescriptionType.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrescriptionType.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PrescriptionType.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrescriptionType.NoClip = EvetHayirEnum.ehEvet;
                    PrescriptionType.ObjectDefName = "PrescriptionTypeEnum";
                    PrescriptionType.DataMember = "DISPLAYTEXT";
                    PrescriptionType.Value = @"{@PRESCRIPTIONTYPE@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LOGO.CalcValue = LOGO.Value;
                    ReportName.CalcValue = ReportName.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField112.CalcValue = NewField112.Value;
                    NewField1211.CalcValue = NewField1211.Value;
                    NewField1212.CalcValue = NewField1212.Value;
                    StartDate.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    EndDate.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    PrescriptionType.CalcValue = MyParentReport.RuntimeParameters.PRESCRIPTIONTYPE.ToString();
                    PrescriptionType.PostFieldValueCalculation();
                    return new TTReportObject[] { LOGO,ReportName,NewField1,NewField11,NewField111,NewField112,NewField1211,NewField1212,StartDate,EndDate,PrescriptionType};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public PrescriptionStatisticWithGroupReport MyParentReport
                {
                    get { return (PrescriptionStatisticWithGroupReport)ParentReport; }
                }
                
                public TTReportField PrintDate;
                public TTReportField PageNumber;
                public TTReportField CurrentUser;
                public TTReportShape NewLine111; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 35;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 25, 5, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdate@}";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 0, 257, 5, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu.{@pagenumber@}/{@pagecount@}";

                    CurrentUser = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 0, 142, 5, false);
                    CurrentUser.Name = "CurrentUser";
                    CurrentUser.FieldType = ReportFieldTypeEnum.ftExpression;
                    CurrentUser.CaseFormat = CaseFormatEnum.fcNameSurname;
                    CurrentUser.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CurrentUser.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CurrentUser.NoClip = EvetHayirEnum.ehEvet;
                    CurrentUser.TextFont.Size = 8;
                    CurrentUser.TextFont.CharSet = 162;
                    CurrentUser.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 0, 257, 0, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString();
                    PageNumber.CalcValue = @"Sayfa Nu." + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    CurrentUser.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PrintDate,PageNumber,CurrentUser};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public PrescriptionStatisticWithGroupReport MyParentReport
            {
                get { return (PrescriptionStatisticWithGroupReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField1112 { get {return Header().NewField1112;} }
            public TTReportField NewField12111 { get {return Header().NewField12111;} }
            public TTReportField NewField12112 { get {return Header().NewField12112;} }
            public TTReportField NewField12113 { get {return Header().NewField12113;} }
            public TTReportField NewField12114 { get {return Header().NewField12114;} }
            public TTReportField NewField131121 { get {return Header().NewField131121;} }
            public TTReportField NewField131122 { get {return Header().NewField131122;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField OfficerTotal1 { get {return Footer().OfficerTotal1;} }
            public TTReportField NoncommissionedOfficerTotal1 { get {return Footer().NoncommissionedOfficerTotal1;} }
            public TTReportField MilitaryCivilOfficialTotal1 { get {return Footer().MilitaryCivilOfficialTotal1;} }
            public TTReportField ExpertNonComTotal1 { get {return Footer().ExpertNonComTotal1;} }
            public TTReportField PrivateNonComTotal1 { get {return Footer().PrivateNonComTotal1;} }
            public TTReportField CadetTotal1 { get {return Footer().CadetTotal1;} }
            public TTReportField RetiredTotal1 { get {return Footer().RetiredTotal1;} }
            public TTReportField FamilyTotal1 { get {return Footer().FamilyTotal1;} }
            public TTReportField CivilianTotal1 { get {return Footer().CivilianTotal1;} }
            public TTReportField GrandTotal1 { get {return Footer().GrandTotal1;} }
            public TTReportField NewField121 { get {return Footer().NewField121;} }
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
                public PrescriptionStatisticWithGroupReport MyParentReport
                {
                    get { return (PrescriptionStatisticWithGroupReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField111;
                public TTReportField NewField1111;
                public TTReportField NewField1112;
                public TTReportField NewField12111;
                public TTReportField NewField12112;
                public TTReportField NewField12113;
                public TTReportField NewField12114;
                public TTReportField NewField131121;
                public TTReportField NewField131122;
                public TTReportShape NewLine1; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 7;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 64, 5, false);
                    NewField1.Name = "NewField1";
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Size = 11;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Poliklinikler";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 242, 0, 257, 5, false);
                    NewField11.Name = "NewField11";
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Size = 11;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Toplam";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 226, 0, 241, 5, false);
                    NewField111.Name = "NewField111";
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Size = 11;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"Sivil";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 194, 0, 209, 5, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Size = 11;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"Emekli";

                    NewField1112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 0, 193, 5, false);
                    NewField1112.Name = "NewField1112";
                    NewField1112.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField1112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1112.TextFont.Size = 11;
                    NewField1112.TextFont.Bold = true;
                    NewField1112.TextFont.CharSet = 162;
                    NewField1112.Value = @"XXXXXX Öğrenci";

                    NewField12111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 0, 167, 5, false);
                    NewField12111.Name = "NewField12111";
                    NewField12111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField12111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12111.TextFont.Size = 11;
                    NewField12111.TextFont.Bold = true;
                    NewField12111.TextFont.CharSet = 162;
                    NewField12111.Value = @"Er Erbaş";

                    NewField12112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 128, 0, 151, 5, false);
                    NewField12112.Name = "NewField12112";
                    NewField12112.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField12112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12112.TextFont.Size = 11;
                    NewField12112.TextFont.Bold = true;
                    NewField12112.TextFont.CharSet = 162;
                    NewField12112.Value = @"Uzman Erbaş";

                    NewField12113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 102, 0, 127, 5, false);
                    NewField12113.Name = "NewField12113";
                    NewField12113.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField12113.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12113.TextFont.Size = 11;
                    NewField12113.TextFont.Bold = true;
                    NewField12113.TextFont.CharSet = 162;
                    NewField12113.Value = @"Sivil Memur";

                    NewField12114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 210, 0, 225, 5, false);
                    NewField12114.Name = "NewField12114";
                    NewField12114.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField12114.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12114.TextFont.Size = 11;
                    NewField12114.TextFont.Bold = true;
                    NewField12114.TextFont.CharSet = 162;
                    NewField12114.Value = @"Aile";

                    NewField131121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 0, 101, 5, false);
                    NewField131121.Name = "NewField131121";
                    NewField131121.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField131121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131121.TextFont.Size = 11;
                    NewField131121.TextFont.Bold = true;
                    NewField131121.TextFont.CharSet = 162;
                    NewField131121.Value = @"Astsubay";

                    NewField131122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 0, 80, 5, false);
                    NewField131122.Name = "NewField131122";
                    NewField131122.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField131122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131122.TextFont.Size = 11;
                    NewField131122.TextFont.Bold = true;
                    NewField131122.TextFont.CharSet = 162;
                    NewField131122.Value = @"Subay";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 5, 257, 5, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField1112.CalcValue = NewField1112.Value;
                    NewField12111.CalcValue = NewField12111.Value;
                    NewField12112.CalcValue = NewField12112.Value;
                    NewField12113.CalcValue = NewField12113.Value;
                    NewField12114.CalcValue = NewField12114.Value;
                    NewField131121.CalcValue = NewField131121.Value;
                    NewField131122.CalcValue = NewField131122.Value;
                    return new TTReportObject[] { NewField1,NewField11,NewField111,NewField1111,NewField1112,NewField12111,NewField12112,NewField12113,NewField12114,NewField131121,NewField131122};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public PrescriptionStatisticWithGroupReport MyParentReport
                {
                    get { return (PrescriptionStatisticWithGroupReport)ParentReport; }
                }
                
                public TTReportField OfficerTotal1;
                public TTReportField NoncommissionedOfficerTotal1;
                public TTReportField MilitaryCivilOfficialTotal1;
                public TTReportField ExpertNonComTotal1;
                public TTReportField PrivateNonComTotal1;
                public TTReportField CadetTotal1;
                public TTReportField RetiredTotal1;
                public TTReportField FamilyTotal1;
                public TTReportField CivilianTotal1;
                public TTReportField GrandTotal1;
                public TTReportField NewField121; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 8;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    OfficerTotal1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 1, 79, 6, false);
                    OfficerTotal1.Name = "OfficerTotal1";
                    OfficerTotal1.FieldType = ReportFieldTypeEnum.ftVariable;
                    OfficerTotal1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    OfficerTotal1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OfficerTotal1.Value = @"{@sumof(OfficerTotal)@}";

                    NoncommissionedOfficerTotal1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 1, 100, 6, false);
                    NoncommissionedOfficerTotal1.Name = "NoncommissionedOfficerTotal1";
                    NoncommissionedOfficerTotal1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NoncommissionedOfficerTotal1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NoncommissionedOfficerTotal1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NoncommissionedOfficerTotal1.Value = @"{@sumof(NoncommissionedOfficerTotal)@}";

                    MilitaryCivilOfficialTotal1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 1, 126, 6, false);
                    MilitaryCivilOfficialTotal1.Name = "MilitaryCivilOfficialTotal1";
                    MilitaryCivilOfficialTotal1.FieldType = ReportFieldTypeEnum.ftVariable;
                    MilitaryCivilOfficialTotal1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    MilitaryCivilOfficialTotal1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MilitaryCivilOfficialTotal1.Value = @"{@sumof(MilitaryCivilOfficialTotal)@}";

                    ExpertNonComTotal1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 1, 150, 6, false);
                    ExpertNonComTotal1.Name = "ExpertNonComTotal1";
                    ExpertNonComTotal1.FieldType = ReportFieldTypeEnum.ftVariable;
                    ExpertNonComTotal1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ExpertNonComTotal1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ExpertNonComTotal1.Value = @"{@sumof(ExpertNonComTotal)@}";

                    PrivateNonComTotal1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 1, 166, 6, false);
                    PrivateNonComTotal1.Name = "PrivateNonComTotal1";
                    PrivateNonComTotal1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrivateNonComTotal1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PrivateNonComTotal1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrivateNonComTotal1.Value = @"{@sumof(PrivateNonComTotal)@}";

                    CadetTotal1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 1, 192, 6, false);
                    CadetTotal1.Name = "CadetTotal1";
                    CadetTotal1.FieldType = ReportFieldTypeEnum.ftVariable;
                    CadetTotal1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    CadetTotal1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CadetTotal1.Value = @"{@sumof(CadetTotal)@}";

                    RetiredTotal1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 193, 1, 208, 6, false);
                    RetiredTotal1.Name = "RetiredTotal1";
                    RetiredTotal1.FieldType = ReportFieldTypeEnum.ftVariable;
                    RetiredTotal1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    RetiredTotal1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RetiredTotal1.Value = @"{@sumof(RetiredTotal)@}";

                    FamilyTotal1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 209, 1, 224, 6, false);
                    FamilyTotal1.Name = "FamilyTotal1";
                    FamilyTotal1.FieldType = ReportFieldTypeEnum.ftVariable;
                    FamilyTotal1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    FamilyTotal1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FamilyTotal1.Value = @"{@sumof(FamilyTotal)@}";

                    CivilianTotal1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 225, 1, 240, 6, false);
                    CivilianTotal1.Name = "CivilianTotal1";
                    CivilianTotal1.FieldType = ReportFieldTypeEnum.ftVariable;
                    CivilianTotal1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    CivilianTotal1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CivilianTotal1.Value = @"{@sumof(CivilianTotal)@}";

                    GrandTotal1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 241, 1, 256, 6, false);
                    GrandTotal1.Name = "GrandTotal1";
                    GrandTotal1.FieldType = ReportFieldTypeEnum.ftVariable;
                    GrandTotal1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    GrandTotal1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GrandTotal1.Value = @"{@sumof(GrandTotal)@}";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 1, 63, 6, false);
                    NewField121.Name = "NewField121";
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Genel Toplam:";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    OfficerTotal1.CalcValue = ParentGroup.FieldSums["OfficerTotal"].Value.ToString();;
                    NoncommissionedOfficerTotal1.CalcValue = ParentGroup.FieldSums["NoncommissionedOfficerTotal"].Value.ToString();;
                    MilitaryCivilOfficialTotal1.CalcValue = ParentGroup.FieldSums["MilitaryCivilOfficialTotal"].Value.ToString();;
                    ExpertNonComTotal1.CalcValue = ParentGroup.FieldSums["ExpertNonComTotal"].Value.ToString();;
                    PrivateNonComTotal1.CalcValue = ParentGroup.FieldSums["PrivateNonComTotal"].Value.ToString();;
                    CadetTotal1.CalcValue = ParentGroup.FieldSums["CadetTotal"].Value.ToString();;
                    RetiredTotal1.CalcValue = ParentGroup.FieldSums["RetiredTotal"].Value.ToString();;
                    FamilyTotal1.CalcValue = ParentGroup.FieldSums["FamilyTotal"].Value.ToString();;
                    CivilianTotal1.CalcValue = ParentGroup.FieldSums["CivilianTotal"].Value.ToString();;
                    GrandTotal1.CalcValue = ParentGroup.FieldSums["GrandTotal"].Value.ToString();;
                    NewField121.CalcValue = NewField121.Value;
                    return new TTReportObject[] { OfficerTotal1,NoncommissionedOfficerTotal1,MilitaryCivilOfficialTotal1,ExpertNonComTotal1,PrivateNonComTotal1,CadetTotal1,RetiredTotal1,FamilyTotal1,CivilianTotal1,GrandTotal1,NewField121};
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class PARTCGroup : TTReportGroup
        {
            public PrescriptionStatisticWithGroupReport MyParentReport
            {
                get { return (PrescriptionStatisticWithGroupReport)ParentReport; }
            }

            new public PARTCGroupHeader Header()
            {
                return (PARTCGroupHeader)_header;
            }

            new public PARTCGroupFooter Footer()
            {
                return (PARTCGroupFooter)_footer;
            }

            public TTReportField MASTERRESOURCEID { get {return Header().MASTERRESOURCEID;} }
            public TTReportField OfficerTotal { get {return Footer().OfficerTotal;} }
            public TTReportField NoncommissionedOfficerTotal { get {return Footer().NoncommissionedOfficerTotal;} }
            public TTReportField MilitaryCivilOfficialTotal { get {return Footer().MilitaryCivilOfficialTotal;} }
            public TTReportField ExpertNonComTotal { get {return Footer().ExpertNonComTotal;} }
            public TTReportField PrivateNonComTotal { get {return Footer().PrivateNonComTotal;} }
            public TTReportField CadetTotal { get {return Footer().CadetTotal;} }
            public TTReportField RetiredTotal { get {return Footer().RetiredTotal;} }
            public TTReportField FamilyTotal { get {return Footer().FamilyTotal;} }
            public TTReportField CivilianTotal { get {return Footer().CivilianTotal;} }
            public TTReportField GrandTotal { get {return Footer().GrandTotal;} }
            public PARTCGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTCGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<Prescription.GetPrescriptionStatisticWithGroupReportQuery_Class>("GetPrescriptionStatisticWithGroupReportQuery", Prescription.GetPrescriptionStatisticWithGroupReportQuery((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),((PrescriptionTypeEnum)TTObjectDefManager.Instance.DataTypes["PrescriptionTypeEnum"].EnumValueDefs[MyParentReport.RuntimeParameters.PRESCRIPTIONTYPE.ToString()].EnumValue)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTCGroupHeader(this);
                _footer = new PARTCGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTCGroupHeader : TTReportSection
            {
                public PrescriptionStatisticWithGroupReport MyParentReport
                {
                    get { return (PrescriptionStatisticWithGroupReport)ParentReport; }
                }
                
                public TTReportField MASTERRESOURCEID; 
                public PARTCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 11;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    MASTERRESOURCEID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 1, 84, 6, false);
                    MASTERRESOURCEID.Name = "MASTERRESOURCEID";
                    MASTERRESOURCEID.Visible = EvetHayirEnum.ehHayir;
                    MASTERRESOURCEID.FieldType = ReportFieldTypeEnum.ftVariable;
                    MASTERRESOURCEID.Value = @"{#MASTERRESOURCEID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Prescription.GetPrescriptionStatisticWithGroupReportQuery_Class dataset_GetPrescriptionStatisticWithGroupReportQuery = ParentGroup.rsGroup.GetCurrentRecord<Prescription.GetPrescriptionStatisticWithGroupReportQuery_Class>(0);
                    MASTERRESOURCEID.CalcValue = (dataset_GetPrescriptionStatisticWithGroupReportQuery != null ? Globals.ToStringCore(dataset_GetPrescriptionStatisticWithGroupReportQuery.Masterresourceid) : "");
                    return new TTReportObject[] { MASTERRESOURCEID};
                }
            }
            public partial class PARTCGroupFooter : TTReportSection
            {
                public PrescriptionStatisticWithGroupReport MyParentReport
                {
                    get { return (PrescriptionStatisticWithGroupReport)ParentReport; }
                }
                
                public TTReportField OfficerTotal;
                public TTReportField NoncommissionedOfficerTotal;
                public TTReportField MilitaryCivilOfficialTotal;
                public TTReportField ExpertNonComTotal;
                public TTReportField PrivateNonComTotal;
                public TTReportField CadetTotal;
                public TTReportField RetiredTotal;
                public TTReportField FamilyTotal;
                public TTReportField CivilianTotal;
                public TTReportField GrandTotal; 
                public PARTCGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 7;
                    IsVisible = EvetHayirEnum.ehHayir;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    OfficerTotal = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 1, 80, 6, false);
                    OfficerTotal.Name = "OfficerTotal";
                    OfficerTotal.FieldType = ReportFieldTypeEnum.ftVariable;
                    OfficerTotal.HorzAlign = HorizontalAlignmentEnum.haRight;
                    OfficerTotal.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OfficerTotal.Value = @"{@sumof(Officer)@}";

                    NoncommissionedOfficerTotal = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 1, 101, 6, false);
                    NoncommissionedOfficerTotal.Name = "NoncommissionedOfficerTotal";
                    NoncommissionedOfficerTotal.FieldType = ReportFieldTypeEnum.ftVariable;
                    NoncommissionedOfficerTotal.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NoncommissionedOfficerTotal.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NoncommissionedOfficerTotal.Value = @"{@sumof(NoncommissionedOfficer)@}";

                    MilitaryCivilOfficialTotal = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 102, 1, 127, 6, false);
                    MilitaryCivilOfficialTotal.Name = "MilitaryCivilOfficialTotal";
                    MilitaryCivilOfficialTotal.FieldType = ReportFieldTypeEnum.ftVariable;
                    MilitaryCivilOfficialTotal.HorzAlign = HorizontalAlignmentEnum.haRight;
                    MilitaryCivilOfficialTotal.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MilitaryCivilOfficialTotal.Value = @"{@sumof(MilitaryCivilOfficial)@}";

                    ExpertNonComTotal = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 128, 1, 151, 6, false);
                    ExpertNonComTotal.Name = "ExpertNonComTotal";
                    ExpertNonComTotal.FieldType = ReportFieldTypeEnum.ftVariable;
                    ExpertNonComTotal.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ExpertNonComTotal.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ExpertNonComTotal.Value = @"{@sumof(ExpertNonCom)@}";

                    PrivateNonComTotal = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 1, 167, 6, false);
                    PrivateNonComTotal.Name = "PrivateNonComTotal";
                    PrivateNonComTotal.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrivateNonComTotal.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PrivateNonComTotal.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrivateNonComTotal.Value = @"{@sumof(PrivateNonCom)@}";

                    CadetTotal = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 1, 193, 6, false);
                    CadetTotal.Name = "CadetTotal";
                    CadetTotal.FieldType = ReportFieldTypeEnum.ftVariable;
                    CadetTotal.HorzAlign = HorizontalAlignmentEnum.haRight;
                    CadetTotal.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CadetTotal.Value = @"{@sumof(Cadet)@}";

                    RetiredTotal = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 194, 1, 209, 6, false);
                    RetiredTotal.Name = "RetiredTotal";
                    RetiredTotal.FieldType = ReportFieldTypeEnum.ftVariable;
                    RetiredTotal.HorzAlign = HorizontalAlignmentEnum.haRight;
                    RetiredTotal.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RetiredTotal.Value = @"{@sumof(Retired)@}";

                    FamilyTotal = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 210, 1, 225, 6, false);
                    FamilyTotal.Name = "FamilyTotal";
                    FamilyTotal.FieldType = ReportFieldTypeEnum.ftVariable;
                    FamilyTotal.HorzAlign = HorizontalAlignmentEnum.haRight;
                    FamilyTotal.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FamilyTotal.Value = @"{@sumof(Family)@}";

                    CivilianTotal = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 226, 1, 241, 6, false);
                    CivilianTotal.Name = "CivilianTotal";
                    CivilianTotal.FieldType = ReportFieldTypeEnum.ftVariable;
                    CivilianTotal.HorzAlign = HorizontalAlignmentEnum.haRight;
                    CivilianTotal.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CivilianTotal.Value = @"{@sumof(Civilian)@}";

                    GrandTotal = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 242, 1, 257, 6, false);
                    GrandTotal.Name = "GrandTotal";
                    GrandTotal.FieldType = ReportFieldTypeEnum.ftVariable;
                    GrandTotal.HorzAlign = HorizontalAlignmentEnum.haRight;
                    GrandTotal.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GrandTotal.Value = @"{@sumof(Total)@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Prescription.GetPrescriptionStatisticWithGroupReportQuery_Class dataset_GetPrescriptionStatisticWithGroupReportQuery = ParentGroup.rsGroup.GetCurrentRecord<Prescription.GetPrescriptionStatisticWithGroupReportQuery_Class>(0);
                    OfficerTotal.CalcValue = ParentGroup.FieldSums["Officer"].Value.ToString();;
                    NoncommissionedOfficerTotal.CalcValue = ParentGroup.FieldSums["NoncommissionedOfficer"].Value.ToString();;
                    MilitaryCivilOfficialTotal.CalcValue = ParentGroup.FieldSums["MilitaryCivilOfficial"].Value.ToString();;
                    ExpertNonComTotal.CalcValue = ParentGroup.FieldSums["ExpertNonCom"].Value.ToString();;
                    PrivateNonComTotal.CalcValue = ParentGroup.FieldSums["PrivateNonCom"].Value.ToString();;
                    CadetTotal.CalcValue = ParentGroup.FieldSums["Cadet"].Value.ToString();;
                    RetiredTotal.CalcValue = ParentGroup.FieldSums["Retired"].Value.ToString();;
                    FamilyTotal.CalcValue = ParentGroup.FieldSums["Family"].Value.ToString();;
                    CivilianTotal.CalcValue = ParentGroup.FieldSums["Civilian"].Value.ToString();;
                    GrandTotal.CalcValue = ParentGroup.FieldSums["Total"].Value.ToString();;
                    return new TTReportObject[] { OfficerTotal,NoncommissionedOfficerTotal,MilitaryCivilOfficialTotal,ExpertNonComTotal,PrivateNonComTotal,CadetTotal,RetiredTotal,FamilyTotal,CivilianTotal,GrandTotal};
                }
            }

        }

        public PARTCGroup PARTC;

        public partial class MAINGroup : TTReportGroup
        {
            public PrescriptionStatisticWithGroupReport MyParentReport
            {
                get { return (PrescriptionStatisticWithGroupReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField MasterResource { get {return Body().MasterResource;} }
            public TTReportField Officer { get {return Body().Officer;} }
            public TTReportField NoncommissionedOfficer { get {return Body().NoncommissionedOfficer;} }
            public TTReportField MilitaryCivilOfficial { get {return Body().MilitaryCivilOfficial;} }
            public TTReportField ExpertNonCom { get {return Body().ExpertNonCom;} }
            public TTReportField PrivateNonCom { get {return Body().PrivateNonCom;} }
            public TTReportField Cadet { get {return Body().Cadet;} }
            public TTReportField Retired { get {return Body().Retired;} }
            public TTReportField Family { get {return Body().Family;} }
            public TTReportField Civilian { get {return Body().Civilian;} }
            public TTReportField Total { get {return Body().Total;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
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
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[9];
                list[0] = new TTReportNqlData<Prescription.GetOfficerForPrescriptionStatisticReportQuery_Class>("GetOfficerForPrescriptionStatisticReportQuery", Prescription.GetOfficerForPrescriptionStatisticReportQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.PARTC.MASTERRESOURCEID.CalcValue),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),((PrescriptionTypeEnum)TTObjectDefManager.Instance.DataTypes["PrescriptionTypeEnum"].EnumValueDefs[MyParentReport.RuntimeParameters.PRESCRIPTIONTYPE.ToString()].EnumValue)));
                list[1] = new TTReportNqlData<Prescription.GetNCOfficerForPrescriptionStatisticReportQuery_Class>("GetNCOfficerForPrescriptionStatisticReportQuery", Prescription.GetNCOfficerForPrescriptionStatisticReportQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.PARTC.MASTERRESOURCEID.CalcValue),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),((PrescriptionTypeEnum)TTObjectDefManager.Instance.DataTypes["PrescriptionTypeEnum"].EnumValueDefs[MyParentReport.RuntimeParameters.PRESCRIPTIONTYPE.ToString()].EnumValue)));
                list[2] = new TTReportNqlData<Prescription.GetOfficialForPrescriptionStatisticReportQuery_Class>("GetOfficialForPrescriptionStatisticReportQuery", Prescription.GetOfficialForPrescriptionStatisticReportQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.PARTC.MASTERRESOURCEID.CalcValue),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),((PrescriptionTypeEnum)TTObjectDefManager.Instance.DataTypes["PrescriptionTypeEnum"].EnumValueDefs[MyParentReport.RuntimeParameters.PRESCRIPTIONTYPE.ToString()].EnumValue)));
                list[3] = new TTReportNqlData<Prescription.GetExpertNonComForPrescriptionStatisticReportQuery_Class>("GetExpertNonComForPrescriptionStatisticReportQuery", Prescription.GetExpertNonComForPrescriptionStatisticReportQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.PARTC.MASTERRESOURCEID.CalcValue),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),((PrescriptionTypeEnum)TTObjectDefManager.Instance.DataTypes["PrescriptionTypeEnum"].EnumValueDefs[MyParentReport.RuntimeParameters.PRESCRIPTIONTYPE.ToString()].EnumValue)));
                list[4] = new TTReportNqlData<Prescription.GetPrivateForPrescriptionStatisticReportQuery_Class>("GetPrivateForPrescriptionStatisticReportQuery", Prescription.GetPrivateForPrescriptionStatisticReportQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.PARTC.MASTERRESOURCEID.CalcValue),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),((PrescriptionTypeEnum)TTObjectDefManager.Instance.DataTypes["PrescriptionTypeEnum"].EnumValueDefs[MyParentReport.RuntimeParameters.PRESCRIPTIONTYPE.ToString()].EnumValue)));
                list[5] = new TTReportNqlData<Prescription.GetCadetForPrescriptionStatisticReportQuery_Class>("GetCadetForPrescriptionStatisticReportQuery", Prescription.GetCadetForPrescriptionStatisticReportQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.PARTC.MASTERRESOURCEID.CalcValue),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),((PrescriptionTypeEnum)TTObjectDefManager.Instance.DataTypes["PrescriptionTypeEnum"].EnumValueDefs[MyParentReport.RuntimeParameters.PRESCRIPTIONTYPE.ToString()].EnumValue)));
                list[6] = new TTReportNqlData<Prescription.GetRetiredForPrescriptionStatisticReportQuery_Class>("GetRetiredForPrescriptionStatisticReportQuery", Prescription.GetRetiredForPrescriptionStatisticReportQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.PARTC.MASTERRESOURCEID.CalcValue),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),((PrescriptionTypeEnum)TTObjectDefManager.Instance.DataTypes["PrescriptionTypeEnum"].EnumValueDefs[MyParentReport.RuntimeParameters.PRESCRIPTIONTYPE.ToString()].EnumValue)));
                list[7] = new TTReportNqlData<Prescription.GetFamilyForPrescriptionStatisticReportQuery_Class>("GetFamilyForPrescriptionStatisticReportQuery", Prescription.GetFamilyForPrescriptionStatisticReportQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.PARTC.MASTERRESOURCEID.CalcValue),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),((PrescriptionTypeEnum)TTObjectDefManager.Instance.DataTypes["PrescriptionTypeEnum"].EnumValueDefs[MyParentReport.RuntimeParameters.PRESCRIPTIONTYPE.ToString()].EnumValue)));
                list[8] = new TTReportNqlData<Prescription.GetCivilianForPrescriptionStatisticReportQuery_Class>("GetCivilianForPrescriptionStatisticReportQuery", Prescription.GetCivilianForPrescriptionStatisticReportQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.PARTC.MASTERRESOURCEID.CalcValue),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),((PrescriptionTypeEnum)TTObjectDefManager.Instance.DataTypes["PrescriptionTypeEnum"].EnumValueDefs[MyParentReport.RuntimeParameters.PRESCRIPTIONTYPE.ToString()].EnumValue)));
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
                public PrescriptionStatisticWithGroupReport MyParentReport
                {
                    get { return (PrescriptionStatisticWithGroupReport)ParentReport; }
                }
                
                public TTReportField MasterResource;
                public TTReportField Officer;
                public TTReportField NoncommissionedOfficer;
                public TTReportField MilitaryCivilOfficial;
                public TTReportField ExpertNonCom;
                public TTReportField PrivateNonCom;
                public TTReportField Cadet;
                public TTReportField Retired;
                public TTReportField Family;
                public TTReportField Civilian;
                public TTReportField Total;
                public TTReportShape NewLine11; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 8;
                    RepeatCount = 0;
                    
                    MasterResource = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 1, 64, 6, false);
                    MasterResource.Name = "MasterResource";
                    MasterResource.FieldType = ReportFieldTypeEnum.ftVariable;
                    MasterResource.CaseFormat = CaseFormatEnum.fcTitleCase;
                    MasterResource.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MasterResource.WordBreak = EvetHayirEnum.ehEvet;
                    MasterResource.ObjectDefName = "Resource";
                    MasterResource.DataMember = "NAME";
                    MasterResource.Value = @"{%PARTC.MASTERRESOURCEID%}";

                    Officer = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 1, 80, 6, false);
                    Officer.Name = "Officer";
                    Officer.FieldType = ReportFieldTypeEnum.ftVariable;
                    Officer.HorzAlign = HorizontalAlignmentEnum.haRight;
                    Officer.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Officer.Value = @"{#OFFICERCOUNT#}";

                    NoncommissionedOfficer = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 1, 101, 6, false);
                    NoncommissionedOfficer.Name = "NoncommissionedOfficer";
                    NoncommissionedOfficer.FieldType = ReportFieldTypeEnum.ftVariable;
                    NoncommissionedOfficer.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NoncommissionedOfficer.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NoncommissionedOfficer.Value = @"{#NCOFFICERCOUNT!GetNCOfficerForPrescriptionStatisticReportQuery#}";

                    MilitaryCivilOfficial = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 102, 1, 127, 6, false);
                    MilitaryCivilOfficial.Name = "MilitaryCivilOfficial";
                    MilitaryCivilOfficial.FieldType = ReportFieldTypeEnum.ftVariable;
                    MilitaryCivilOfficial.HorzAlign = HorizontalAlignmentEnum.haRight;
                    MilitaryCivilOfficial.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MilitaryCivilOfficial.Value = @"{#OFFICIALCOUNT!GetOfficialForPrescriptionStatisticReportQuery#}";

                    ExpertNonCom = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 128, 1, 151, 6, false);
                    ExpertNonCom.Name = "ExpertNonCom";
                    ExpertNonCom.FieldType = ReportFieldTypeEnum.ftVariable;
                    ExpertNonCom.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ExpertNonCom.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ExpertNonCom.Value = @"{#EXPERTNONCOMCOUNT!GetExpertNonComForPrescriptionStatisticReportQuery#}";

                    PrivateNonCom = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 1, 167, 6, false);
                    PrivateNonCom.Name = "PrivateNonCom";
                    PrivateNonCom.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrivateNonCom.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PrivateNonCom.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrivateNonCom.Value = @"{#PRIVATECOUNT!GetPrivateForPrescriptionStatisticReportQuery#}";

                    Cadet = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 1, 193, 6, false);
                    Cadet.Name = "Cadet";
                    Cadet.FieldType = ReportFieldTypeEnum.ftVariable;
                    Cadet.HorzAlign = HorizontalAlignmentEnum.haRight;
                    Cadet.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Cadet.Value = @"{#CADETCOUNT!GetCadetForPrescriptionStatisticReportQuery#}";

                    Retired = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 194, 1, 209, 6, false);
                    Retired.Name = "Retired";
                    Retired.FieldType = ReportFieldTypeEnum.ftVariable;
                    Retired.HorzAlign = HorizontalAlignmentEnum.haRight;
                    Retired.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Retired.Value = @"{#RETIREDCOUNT!GetRetiredForPrescriptionStatisticReportQuery#}";

                    Family = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 210, 1, 225, 6, false);
                    Family.Name = "Family";
                    Family.FieldType = ReportFieldTypeEnum.ftVariable;
                    Family.HorzAlign = HorizontalAlignmentEnum.haRight;
                    Family.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Family.Value = @"{#FAMILYCOUNT!GetFamilyForPrescriptionStatisticReportQuery#}";

                    Civilian = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 226, 1, 241, 6, false);
                    Civilian.Name = "Civilian";
                    Civilian.FieldType = ReportFieldTypeEnum.ftVariable;
                    Civilian.HorzAlign = HorizontalAlignmentEnum.haRight;
                    Civilian.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Civilian.Value = @"{#CIVILIANCOUNT!GetCivilianForPrescriptionStatisticReportQuery#}";

                    Total = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 242, 1, 257, 6, false);
                    Total.Name = "Total";
                    Total.FieldType = ReportFieldTypeEnum.ftExpression;
                    Total.HorzAlign = HorizontalAlignmentEnum.haRight;
                    Total.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Total.Value = @"(Convert.ToDouble({%Officer%})+Convert.ToDouble({%NoncommissionedOfficer%})+Convert.ToDouble({%MilitaryCivilOfficial%})+Convert.ToDouble({%ExpertNonCom%})+Convert.ToDouble({%PrivateNonCom%})+Convert.ToDouble({%Cadet%})+Convert.ToDouble({%Retired%})+Convert.ToDouble({%Family%})+Convert.ToDouble({%Civilian%})).ToString()";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 7, 257, 7, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Prescription.GetOfficerForPrescriptionStatisticReportQuery_Class dataset_GetOfficerForPrescriptionStatisticReportQuery = ParentGroup.rsGroup.GetCurrentRecord<Prescription.GetOfficerForPrescriptionStatisticReportQuery_Class>(0);
                    Prescription.GetNCOfficerForPrescriptionStatisticReportQuery_Class dataset_GetNCOfficerForPrescriptionStatisticReportQuery = ParentGroup.rsGroup.GetCurrentRecord<Prescription.GetNCOfficerForPrescriptionStatisticReportQuery_Class>(1);
                    Prescription.GetOfficialForPrescriptionStatisticReportQuery_Class dataset_GetOfficialForPrescriptionStatisticReportQuery = ParentGroup.rsGroup.GetCurrentRecord<Prescription.GetOfficialForPrescriptionStatisticReportQuery_Class>(2);
                    Prescription.GetExpertNonComForPrescriptionStatisticReportQuery_Class dataset_GetExpertNonComForPrescriptionStatisticReportQuery = ParentGroup.rsGroup.GetCurrentRecord<Prescription.GetExpertNonComForPrescriptionStatisticReportQuery_Class>(3);
                    Prescription.GetPrivateForPrescriptionStatisticReportQuery_Class dataset_GetPrivateForPrescriptionStatisticReportQuery = ParentGroup.rsGroup.GetCurrentRecord<Prescription.GetPrivateForPrescriptionStatisticReportQuery_Class>(4);
                    Prescription.GetCadetForPrescriptionStatisticReportQuery_Class dataset_GetCadetForPrescriptionStatisticReportQuery = ParentGroup.rsGroup.GetCurrentRecord<Prescription.GetCadetForPrescriptionStatisticReportQuery_Class>(5);
                    Prescription.GetRetiredForPrescriptionStatisticReportQuery_Class dataset_GetRetiredForPrescriptionStatisticReportQuery = ParentGroup.rsGroup.GetCurrentRecord<Prescription.GetRetiredForPrescriptionStatisticReportQuery_Class>(6);
                    Prescription.GetFamilyForPrescriptionStatisticReportQuery_Class dataset_GetFamilyForPrescriptionStatisticReportQuery = ParentGroup.rsGroup.GetCurrentRecord<Prescription.GetFamilyForPrescriptionStatisticReportQuery_Class>(7);
                    Prescription.GetCivilianForPrescriptionStatisticReportQuery_Class dataset_GetCivilianForPrescriptionStatisticReportQuery = ParentGroup.rsGroup.GetCurrentRecord<Prescription.GetCivilianForPrescriptionStatisticReportQuery_Class>(8);
                    MasterResource.CalcValue = MyParentReport.PARTC.MASTERRESOURCEID.CalcValue;
                    MasterResource.PostFieldValueCalculation();
                    Officer.CalcValue = (dataset_GetOfficerForPrescriptionStatisticReportQuery != null ? Globals.ToStringCore(dataset_GetOfficerForPrescriptionStatisticReportQuery.Officercount) : "");
                    NoncommissionedOfficer.CalcValue = (dataset_GetNCOfficerForPrescriptionStatisticReportQuery != null ? Globals.ToStringCore(dataset_GetNCOfficerForPrescriptionStatisticReportQuery.Ncofficercount) : "");
                    MilitaryCivilOfficial.CalcValue = (dataset_GetOfficialForPrescriptionStatisticReportQuery != null ? Globals.ToStringCore(dataset_GetOfficialForPrescriptionStatisticReportQuery.Officialcount) : "");
                    ExpertNonCom.CalcValue = (dataset_GetExpertNonComForPrescriptionStatisticReportQuery != null ? Globals.ToStringCore(dataset_GetExpertNonComForPrescriptionStatisticReportQuery.Expertnoncomcount) : "");
                    PrivateNonCom.CalcValue = (dataset_GetPrivateForPrescriptionStatisticReportQuery != null ? Globals.ToStringCore(dataset_GetPrivateForPrescriptionStatisticReportQuery.Privatecount) : "");
                    Cadet.CalcValue = (dataset_GetCadetForPrescriptionStatisticReportQuery != null ? Globals.ToStringCore(dataset_GetCadetForPrescriptionStatisticReportQuery.Cadetcount) : "");
                    Retired.CalcValue = (dataset_GetRetiredForPrescriptionStatisticReportQuery != null ? Globals.ToStringCore(dataset_GetRetiredForPrescriptionStatisticReportQuery.Retiredcount) : "");
                    Family.CalcValue = (dataset_GetFamilyForPrescriptionStatisticReportQuery != null ? Globals.ToStringCore(dataset_GetFamilyForPrescriptionStatisticReportQuery.Familycount) : "");
                    Civilian.CalcValue = (dataset_GetCivilianForPrescriptionStatisticReportQuery != null ? Globals.ToStringCore(dataset_GetCivilianForPrescriptionStatisticReportQuery.Civiliancount) : "");
                    Total.CalcValue = (Convert.ToDouble(MyParentReport.MAIN.Officer.CalcValue)+Convert.ToDouble(MyParentReport.MAIN.NoncommissionedOfficer.CalcValue)+Convert.ToDouble(MyParentReport.MAIN.MilitaryCivilOfficial.CalcValue)+Convert.ToDouble(MyParentReport.MAIN.ExpertNonCom.CalcValue)+Convert.ToDouble(MyParentReport.MAIN.PrivateNonCom.CalcValue)+Convert.ToDouble(MyParentReport.MAIN.Cadet.CalcValue)+Convert.ToDouble(MyParentReport.MAIN.Retired.CalcValue)+Convert.ToDouble(MyParentReport.MAIN.Family.CalcValue)+Convert.ToDouble(MyParentReport.MAIN.Civilian.CalcValue)).ToString();
                    return new TTReportObject[] { MasterResource,Officer,NoncommissionedOfficer,MilitaryCivilOfficial,ExpertNonCom,PrivateNonCom,Cadet,Retired,Family,Civilian,Total};
                }
            }


            protected override bool RunScript()
            {
#region MAIN_Script
                this.Officer.CalcValue = "0";
            this.NoncommissionedOfficer.CalcValue = "0";
            this.MilitaryCivilOfficial.CalcValue = "0";
            this.ExpertNonCom.CalcValue = "0";
            this.PrivateNonCom.CalcValue = "0";
            this.Cadet.CalcValue = "0";
            this.Retired.CalcValue = "0";
            this.Family.CalcValue = "0";
            this.Civilian.CalcValue = "0";
            return true;
#endregion MAIN_Script
            }
        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public PrescriptionStatisticWithGroupReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            PARTC = new PARTCGroup(PARTB,"PARTC");
            MAIN = new MAINGroup(PARTC,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihini Seçiniz", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihini Seçiniz", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("PRESCRIPTIONTYPE", "", "Reçete Türünü Seçiniz", @"", true, true, false, new Guid("5c575de3-430a-4947-9d86-9273d771d9ee"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("PRESCRIPTIONTYPE"))
                _runtimeParameters.PRESCRIPTIONTYPE = (PrescriptionTypeEnum?)(int?)TTObjectDefManager.Instance.DataTypes["PrescriptionTypeEnum"].ConvertValue(parameters["PRESCRIPTIONTYPE"]);
            Name = "PRESCRIPTIONSTATISTICWITHGROUPREPORT";
            Caption = "Reçete İstatistiği (Gruplu)";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
            UserMarginLeft = 25;
            UserMarginTop = 15;
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
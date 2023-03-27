
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
    /// Medulaya Gönderilmeyecek Hizmet ve Malzemeler Raporu
    /// </summary>
    public partial class MedulaDontSendProcedureAndMaterialReport : TTReport
    {
#region Methods
   public string protocolNo = " ";
        public double amount = 0;
        public double totalAmount = 0;
        public double totalPrice = 0;
        public double price = 0;
   
#endregion Methods

        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public bool? SHOWPROTOCOLNO = (bool?)TTObjectDefManager.Instance.DataTypes["Boolean"].ConvertValue("");
            public List<Guid> BRANCH = new List<Guid>();
            public int? BRANCHFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
        }

        public partial class PARTJGroup : TTReportGroup
        {
            public MedulaDontSendProcedureAndMaterialReport MyParentReport
            {
                get { return (MedulaDontSendProcedureAndMaterialReport)ParentReport; }
            }

            new public PARTJGroupHeader Header()
            {
                return (PARTJGroupHeader)_header;
            }

            new public PARTJGroupFooter Footer()
            {
                return (PARTJGroupFooter)_footer;
            }

            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public PARTJGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTJGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTJGroupHeader(this);
                _footer = new PARTJGroupFooter(this);

            }

            public partial class PARTJGroupHeader : TTReportSection
            {
                public MedulaDontSendProcedureAndMaterialReport MyParentReport
                {
                    get { return (MedulaDontSendProcedureAndMaterialReport)ParentReport; }
                }
                
                public TTReportField STARTDATE;
                public TTReportField ENDDATE; 
                public PARTJGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 8;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 1, 37, 6, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.Visible = EvetHayirEnum.ehHayir;
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"dd/MM/yyyy";
                    STARTDATE.Value = @"{@STARTDATE@}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 1, 64, 6, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.Visible = EvetHayirEnum.ehHayir;
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"dd/MM/yyyy";
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
#region PARTJ HEADER_Script
                    ((MedulaDontSendProcedureAndMaterialReport)ParentReport).RuntimeParameters.STARTDATE = Convert.ToDateTime(STARTDATE.FormattedValue + " 00:00:00");
            ((MedulaDontSendProcedureAndMaterialReport)ParentReport).RuntimeParameters.ENDDATE = Convert.ToDateTime(ENDDATE.FormattedValue + " 23:59:59");
            if (((MedulaDontSendProcedureAndMaterialReport)ParentReport).RuntimeParameters.BRANCH == null)
                ((MedulaDontSendProcedureAndMaterialReport)ParentReport).RuntimeParameters.BRANCHFLAG = 0;
            else
                ((MedulaDontSendProcedureAndMaterialReport)ParentReport).RuntimeParameters.BRANCHFLAG = 1;
#endregion PARTJ HEADER_Script
                }
            }
            public partial class PARTJGroupFooter : TTReportSection
            {
                public MedulaDontSendProcedureAndMaterialReport MyParentReport
                {
                    get { return (MedulaDontSendProcedureAndMaterialReport)ParentReport; }
                }
                 
                public PARTJGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 5;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTJGroup PARTJ;

        public partial class PARTAGroup : TTReportGroup
        {
            public MedulaDontSendProcedureAndMaterialReport MyParentReport
            {
                get { return (MedulaDontSendProcedureAndMaterialReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportField NewField112 { get {return Header().NewField112;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField BOLUM { get {return Header().BOLUM;} }
            public TTReportField CURRENTUSER { get {return Footer().CURRENTUSER;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportShape NewLine1111111 { get {return Footer().NewLine1111111;} }
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
                public MedulaDontSendProcedureAndMaterialReport MyParentReport
                {
                    get { return (MedulaDontSendProcedureAndMaterialReport)ParentReport; }
                }
                
                public TTReportField NewField111;
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField STARTDATE;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField ENDDATE;
                public TTReportField NewField112;
                public TTReportField NewField121;
                public TTReportField BOLUM; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 48;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 19, 206, 24, false);
                    NewField111.Name = "NewField111";
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Size = 12;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"MEDULAYA GÖNDERİLMEYECEK HİZMET VE MALZEMELER RAPORU";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 26, 34, 31, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Size = 8;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Başlangıç Tarihi";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 26, 37, 31, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Size = 8;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @":";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 26, 63, 31, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"Short Date";
                    STARTDATE.TextFont.Size = 8;
                    STARTDATE.TextFont.CharSet = 162;
                    STARTDATE.Value = @"{@STARTDATE@}";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 31, 34, 36, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Size = 8;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Bitiş Tarihi";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 31, 37, 36, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Size = 8;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @":";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 31, 63, 36, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"Short Date";
                    ENDDATE.TextFont.Size = 8;
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"{@ENDDATE@}";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 36, 34, 41, false);
                    NewField112.Name = "NewField112";
                    NewField112.TextFont.Size = 8;
                    NewField112.TextFont.Bold = true;
                    NewField112.TextFont.CharSet = 162;
                    NewField112.Value = @"Bölüm";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 36, 37, 41, false);
                    NewField121.Name = "NewField121";
                    NewField121.TextFont.Size = 8;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @":";

                    BOLUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 36, 206, 47, false);
                    BOLUM.Name = "BOLUM";
                    BOLUM.FieldType = ReportFieldTypeEnum.ftVariable;
                    BOLUM.TextFormat = @"Short Date";
                    BOLUM.TextFont.Size = 8;
                    BOLUM.TextFont.CharSet = 162;
                    BOLUM.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111.CalcValue = NewField111.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    NewField112.CalcValue = NewField112.Value;
                    NewField121.CalcValue = NewField121.Value;
                    BOLUM.CalcValue = @"";
                    return new TTReportObject[] { NewField111,NewField1,NewField2,STARTDATE,NewField11,NewField12,ENDDATE,NewField112,NewField121,BOLUM};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    if(((MedulaDontSendProcedureAndMaterialReport)ParentReport).RuntimeParameters.BRANCHFLAG == 0)
                this.BOLUM.CalcValue = "Hepsi";
            else
            {
                string branslar = "";
                foreach(Guid objectId in ((MedulaDontSendProcedureAndMaterialReport)ParentReport).RuntimeParameters.BRANCH)
                {
                    SpecialityDefinition brans = (SpecialityDefinition)MyParentReport.ReportObjectContext.GetObject(objectId,"SpecialityDefinition");
                    if(brans.Name != null)
                        branslar += brans.Name + ", ";
                }
                this.BOLUM.CalcValue = branslar.Substring(0,branslar.Length-2);
            }
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public MedulaDontSendProcedureAndMaterialReport MyParentReport
                {
                    get { return (MedulaDontSendProcedureAndMaterialReport)ParentReport; }
                }
                
                public TTReportField CURRENTUSER;
                public TTReportField PrintDate;
                public TTReportField PageNumber;
                public TTReportShape NewLine1111111; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 9;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    CURRENTUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 100, 2, 120, 7, false);
                    CURRENTUSER.Name = "CURRENTUSER";
                    CURRENTUSER.FieldType = ReportFieldTypeEnum.ftExpression;
                    CURRENTUSER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CURRENTUSER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CURRENTUSER.TextFont.Name = "Arial";
                    CURRENTUSER.TextFont.Size = 8;
                    CURRENTUSER.TextFont.CharSet = 162;
                    CURRENTUSER.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 2, 38, 7, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"Short Date";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Name = "Arial";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdatetime@}";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 2, 206, 7, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    NewLine1111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 1, 206, 1, false);
                    NewLine1111111.Name = "NewLine1111111";
                    NewLine1111111.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                    PageNumber.CalcValue = @"Sayfa Nu:" + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    CURRENTUSER.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PrintDate,PageNumber,CURRENTUSER};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public MedulaDontSendProcedureAndMaterialReport MyParentReport
            {
                get { return (MedulaDontSendProcedureAndMaterialReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField113211 { get {return Header().NewField113211;} }
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
                public MedulaDontSendProcedureAndMaterialReport MyParentReport
                {
                    get { return (MedulaDontSendProcedureAndMaterialReport)ParentReport; }
                }
                
                public TTReportField NewField113211; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 6;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField113211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 1, 38, 6, false);
                    NewField113211.Name = "NewField113211";
                    NewField113211.TextFont.Size = 8;
                    NewField113211.TextFont.Bold = true;
                    NewField113211.TextFont.Underline = true;
                    NewField113211.TextFont.CharSet = 162;
                    NewField113211.Value = @"HİZMETLER";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField113211.CalcValue = NewField113211.Value;
                    return new TTReportObject[] { NewField113211};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public MedulaDontSendProcedureAndMaterialReport MyParentReport
                {
                    get { return (MedulaDontSendProcedureAndMaterialReport)ParentReport; }
                }
                 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 3;
                    IsVisible = EvetHayirEnum.ehHayir;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTBGroup PARTB;

        public partial class PARTCGroup : TTReportGroup
        {
            public MedulaDontSendProcedureAndMaterialReport MyParentReport
            {
                get { return (MedulaDontSendProcedureAndMaterialReport)ParentReport; }
            }

            new public PARTCGroupHeader Header()
            {
                return (PARTCGroupHeader)_header;
            }

            new public PARTCGroupFooter Footer()
            {
                return (PARTCGroupFooter)_footer;
            }

            public TTReportField NewField11211 { get {return Header().NewField11211;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField NewField11231 { get {return Header().NewField11231;} }
            public TTReportField NewField1122211 { get {return Header().NewField1122211;} }
            public TTReportField NewField11122211 { get {return Header().NewField11122211;} }
            public TTReportShape NewLine11111 { get {return Header().NewLine11111;} }
            public TTReportField NewField11112111 { get {return Footer().NewField11112111;} }
            public TTReportShape NewLine1111 { get {return Footer().NewLine1111;} }
            public TTReportField HIZMETADET { get {return Footer().HIZMETADET;} }
            public TTReportField HIZMETTUTAR { get {return Footer().HIZMETTUTAR;} }
            public PARTCGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTCGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTCGroupHeader(this);
                _footer = new PARTCGroupFooter(this);

            }

            public partial class PARTCGroupHeader : TTReportSection
            {
                public MedulaDontSendProcedureAndMaterialReport MyParentReport
                {
                    get { return (MedulaDontSendProcedureAndMaterialReport)ParentReport; }
                }
                
                public TTReportField NewField11211;
                public TTReportField NewField1121;
                public TTReportField NewField11231;
                public TTReportField NewField1122211;
                public TTReportField NewField11122211;
                public TTReportShape NewLine11111; 
                public PARTCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 6;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 1, 178, 5, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.TextFont.Size = 8;
                    NewField11211.TextFont.Bold = true;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @"Açıklama";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 1, 36, 5, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.TextFont.Size = 8;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"Kod";

                    NewField11231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 1, 17, 5, false);
                    NewField11231.Name = "NewField11231";
                    NewField11231.TextFont.Size = 8;
                    NewField11231.TextFont.Bold = true;
                    NewField11231.TextFont.CharSet = 162;
                    NewField11231.Value = @"Sıra No";

                    NewField1122211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 1, 187, 5, false);
                    NewField1122211.Name = "NewField1122211";
                    NewField1122211.TextFont.Size = 8;
                    NewField1122211.TextFont.Bold = true;
                    NewField1122211.TextFont.CharSet = 162;
                    NewField1122211.Value = @"Adet";

                    NewField11122211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 1, 205, 5, false);
                    NewField11122211.Name = "NewField11122211";
                    NewField11122211.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField11122211.TextFont.Size = 8;
                    NewField11122211.TextFont.Bold = true;
                    NewField11122211.TextFont.CharSet = 162;
                    NewField11122211.Value = @"Tutar";

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 6, 206, 6, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField11231.CalcValue = NewField11231.Value;
                    NewField1122211.CalcValue = NewField1122211.Value;
                    NewField11122211.CalcValue = NewField11122211.Value;
                    return new TTReportObject[] { NewField11211,NewField1121,NewField11231,NewField1122211,NewField11122211};
                }
            }
            public partial class PARTCGroupFooter : TTReportSection
            {
                public MedulaDontSendProcedureAndMaterialReport MyParentReport
                {
                    get { return (MedulaDontSendProcedureAndMaterialReport)ParentReport; }
                }
                
                public TTReportField NewField11112111;
                public TTReportShape NewLine1111;
                public TTReportField HIZMETADET;
                public TTReportField HIZMETTUTAR; 
                public PARTCGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 8;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField11112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 2, 178, 7, false);
                    NewField11112111.Name = "NewField11112111";
                    NewField11112111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField11112111.TextFont.Size = 8;
                    NewField11112111.TextFont.Bold = true;
                    NewField11112111.TextFont.CharSet = 162;
                    NewField11112111.Value = @"Hizmet Toplam :";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 1, 206, 1, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;

                    HIZMETADET = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 2, 187, 6, false);
                    HIZMETADET.Name = "HIZMETADET";
                    HIZMETADET.FieldType = ReportFieldTypeEnum.ftVariable;
                    HIZMETADET.MultiLine = EvetHayirEnum.ehEvet;
                    HIZMETADET.NoClip = EvetHayirEnum.ehEvet;
                    HIZMETADET.WordBreak = EvetHayirEnum.ehEvet;
                    HIZMETADET.ExpandTabs = EvetHayirEnum.ehEvet;
                    HIZMETADET.TextFont.Size = 8;
                    HIZMETADET.TextFont.CharSet = 162;
                    HIZMETADET.Value = @"";

                    HIZMETTUTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 2, 205, 6, false);
                    HIZMETTUTAR.Name = "HIZMETTUTAR";
                    HIZMETTUTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    HIZMETTUTAR.TextFormat = @"#,##0.#0";
                    HIZMETTUTAR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    HIZMETTUTAR.MultiLine = EvetHayirEnum.ehEvet;
                    HIZMETTUTAR.NoClip = EvetHayirEnum.ehEvet;
                    HIZMETTUTAR.WordBreak = EvetHayirEnum.ehEvet;
                    HIZMETTUTAR.ExpandTabs = EvetHayirEnum.ehEvet;
                    HIZMETTUTAR.TextFont.Size = 8;
                    HIZMETTUTAR.TextFont.CharSet = 162;
                    HIZMETTUTAR.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11112111.CalcValue = NewField11112111.Value;
                    HIZMETADET.CalcValue = @"";
                    HIZMETTUTAR.CalcValue = @"";
                    return new TTReportObject[] { NewField11112111,HIZMETADET,HIZMETTUTAR};
                }

                public override void RunScript()
                {
#region PARTC FOOTER_Script
                    HIZMETADET.CalcValue = (((MedulaDontSendProcedureAndMaterialReport)ParentReport).totalAmount).ToString() ;
            HIZMETTUTAR.CalcValue = (((MedulaDontSendProcedureAndMaterialReport)ParentReport).totalPrice).ToString() ;
            ((MedulaDontSendProcedureAndMaterialReport)ParentReport).totalAmount = 0;
            ((MedulaDontSendProcedureAndMaterialReport)ParentReport).totalPrice = 0;
#endregion PARTC FOOTER_Script
                }
            }

        }

        public PARTCGroup PARTC;

        public partial class PARTXGroup : TTReportGroup
        {
            public MedulaDontSendProcedureAndMaterialReport MyParentReport
            {
                get { return (MedulaDontSendProcedureAndMaterialReport)ParentReport; }
            }

            new public PARTXGroupHeader Header()
            {
                return (PARTXGroupHeader)_header;
            }

            new public PARTXGroupFooter Footer()
            {
                return (PARTXGroupFooter)_footer;
            }

            public TTReportField ACIKLAMA { get {return Footer().ACIKLAMA;} }
            public TTReportField KOD { get {return Footer().KOD;} }
            public TTReportField SIRANO { get {return Footer().SIRANO;} }
            public TTReportField ADET { get {return Footer().ADET;} }
            public TTReportField TUTAR { get {return Footer().TUTAR;} }
            public TTReportField PROTOCOLNO { get {return Footer().PROTOCOLNO;} }
            public TTReportField PROTOCOLNOLABEL { get {return Footer().PROTOCOLNOLABEL;} }
            public TTReportShape PROTOCOLNOLINE { get {return Footer().PROTOCOLNOLINE;} }
            public PARTXGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTXGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<AccountTransaction.GetMedulaDontSendProcedureTrxsByDate_Class>("GetMedulaDontSendProcedureTrxsByDate", AccountTransaction.GetMedulaDontSendProcedureTrxsByDate((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(List<Guid>) MyParentReport.RuntimeParameters.BRANCH,(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.BRANCHFLAG)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTXGroupHeader(this);
                _footer = new PARTXGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTXGroupHeader : TTReportSection
            {
                public MedulaDontSendProcedureAndMaterialReport MyParentReport
                {
                    get { return (MedulaDontSendProcedureAndMaterialReport)ParentReport; }
                }
                 
                public PARTXGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 2;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                

                public override void RunScript()
                {
#region PARTX HEADER_Script
                    ((MedulaDontSendProcedureAndMaterialReport)ParentReport).amount = 0;
            ((MedulaDontSendProcedureAndMaterialReport)ParentReport).price = 0;
            ((MedulaDontSendProcedureAndMaterialReport)ParentReport).protocolNo = " ";
#endregion PARTX HEADER_Script
                }
            }
            public partial class PARTXGroupFooter : TTReportSection
            {
                public MedulaDontSendProcedureAndMaterialReport MyParentReport
                {
                    get { return (MedulaDontSendProcedureAndMaterialReport)ParentReport; }
                }
                
                public TTReportField ACIKLAMA;
                public TTReportField KOD;
                public TTReportField SIRANO;
                public TTReportField ADET;
                public TTReportField TUTAR;
                public TTReportField PROTOCOLNO;
                public TTReportField PROTOCOLNOLABEL;
                public TTReportShape PROTOCOLNOLINE; 
                public PARTXGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 11;
                    RepeatCount = 0;
                    
                    ACIKLAMA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 1, 178, 5, false);
                    ACIKLAMA.Name = "ACIKLAMA";
                    ACIKLAMA.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACIKLAMA.TextFont.Size = 8;
                    ACIKLAMA.TextFont.CharSet = 162;
                    ACIKLAMA.Value = @"{#ACIKLAMA#}";

                    KOD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 1, 36, 5, false);
                    KOD.Name = "KOD";
                    KOD.FieldType = ReportFieldTypeEnum.ftVariable;
                    KOD.MultiLine = EvetHayirEnum.ehEvet;
                    KOD.NoClip = EvetHayirEnum.ehEvet;
                    KOD.WordBreak = EvetHayirEnum.ehEvet;
                    KOD.ExpandTabs = EvetHayirEnum.ehEvet;
                    KOD.TextFont.Size = 8;
                    KOD.TextFont.CharSet = 162;
                    KOD.Value = @"{#KOD#}";

                    SIRANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 1, 17, 5, false);
                    SIRANO.Name = "SIRANO";
                    SIRANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIRANO.MultiLine = EvetHayirEnum.ehEvet;
                    SIRANO.NoClip = EvetHayirEnum.ehEvet;
                    SIRANO.WordBreak = EvetHayirEnum.ehEvet;
                    SIRANO.ExpandTabs = EvetHayirEnum.ehEvet;
                    SIRANO.TextFont.Size = 8;
                    SIRANO.TextFont.CharSet = 162;
                    SIRANO.Value = @"{@groupcounter@}";

                    ADET = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 1, 187, 5, false);
                    ADET.Name = "ADET";
                    ADET.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADET.MultiLine = EvetHayirEnum.ehEvet;
                    ADET.NoClip = EvetHayirEnum.ehEvet;
                    ADET.WordBreak = EvetHayirEnum.ehEvet;
                    ADET.ExpandTabs = EvetHayirEnum.ehEvet;
                    ADET.TextFont.Size = 8;
                    ADET.TextFont.CharSet = 162;
                    ADET.Value = @"";

                    TUTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 1, 205, 5, false);
                    TUTAR.Name = "TUTAR";
                    TUTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    TUTAR.TextFormat = @"#,##0.#0";
                    TUTAR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TUTAR.MultiLine = EvetHayirEnum.ehEvet;
                    TUTAR.NoClip = EvetHayirEnum.ehEvet;
                    TUTAR.WordBreak = EvetHayirEnum.ehEvet;
                    TUTAR.ExpandTabs = EvetHayirEnum.ehEvet;
                    TUTAR.TextFont.Size = 8;
                    TUTAR.TextFont.CharSet = 162;
                    TUTAR.Value = @"";

                    PROTOCOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 6, 205, 10, false);
                    PROTOCOLNO.Name = "PROTOCOLNO";
                    PROTOCOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOCOLNO.MultiLine = EvetHayirEnum.ehEvet;
                    PROTOCOLNO.NoClip = EvetHayirEnum.ehEvet;
                    PROTOCOLNO.WordBreak = EvetHayirEnum.ehEvet;
                    PROTOCOLNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    PROTOCOLNO.TextFont.Size = 8;
                    PROTOCOLNO.TextFont.CharSet = 162;
                    PROTOCOLNO.Value = @"";

                    PROTOCOLNOLABEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 6, 25, 10, false);
                    PROTOCOLNOLABEL.Name = "PROTOCOLNOLABEL";
                    PROTOCOLNOLABEL.TextFont.Size = 8;
                    PROTOCOLNOLABEL.TextFont.Bold = true;
                    PROTOCOLNOLABEL.TextFont.CharSet = 162;
                    PROTOCOLNOLABEL.Value = @"Protokol No :";

                    PROTOCOLNOLINE = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 0, 206, 0, false);
                    PROTOCOLNOLINE.Name = "PROTOCOLNOLINE";
                    PROTOCOLNOLINE.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    AccountTransaction.GetMedulaDontSendProcedureTrxsByDate_Class dataset_GetMedulaDontSendProcedureTrxsByDate = ParentGroup.rsGroup.GetCurrentRecord<AccountTransaction.GetMedulaDontSendProcedureTrxsByDate_Class>(0);
                    ACIKLAMA.CalcValue = (dataset_GetMedulaDontSendProcedureTrxsByDate != null ? Globals.ToStringCore(dataset_GetMedulaDontSendProcedureTrxsByDate.Aciklama) : "");
                    KOD.CalcValue = (dataset_GetMedulaDontSendProcedureTrxsByDate != null ? Globals.ToStringCore(dataset_GetMedulaDontSendProcedureTrxsByDate.Kod) : "");
                    SIRANO.CalcValue = ParentGroup.GroupCounter.ToString();
                    ADET.CalcValue = @"";
                    TUTAR.CalcValue = @"";
                    PROTOCOLNO.CalcValue = @"";
                    PROTOCOLNOLABEL.CalcValue = PROTOCOLNOLABEL.Value;
                    return new TTReportObject[] { ACIKLAMA,KOD,SIRANO,ADET,TUTAR,PROTOCOLNO,PROTOCOLNOLABEL};
                }

                public override void RunScript()
                {
#region PARTX FOOTER_Script
                    ADET.CalcValue = (((MedulaDontSendProcedureAndMaterialReport)ParentReport).amount).ToString();
            TUTAR.CalcValue = (((MedulaDontSendProcedureAndMaterialReport)ParentReport).price).ToString();
            if(((MedulaDontSendProcedureAndMaterialReport)ParentReport).RuntimeParameters.SHOWPROTOCOLNO == true)
            {
                string protocolNo = ((MedulaDontSendProcedureAndMaterialReport)ParentReport).protocolNo ;
                PROTOCOLNO.CalcValue = protocolNo.Substring(0, protocolNo.Length - 2);
                PROTOCOLNO.Visible = EvetHayirEnum.ehEvet;
                PROTOCOLNOLABEL.Visible = EvetHayirEnum.ehEvet;
                PROTOCOLNOLINE.Visible = EvetHayirEnum.ehEvet;
            }
            else
            {
                PROTOCOLNO.Visible = EvetHayirEnum.ehHayir;
                PROTOCOLNOLABEL.Visible = EvetHayirEnum.ehHayir;
                PROTOCOLNOLINE.Visible = EvetHayirEnum.ehHayir;
            }
#endregion PARTX FOOTER_Script
                }
            }

        }

        public PARTXGroup PARTX;

        public partial class MAINGroup : TTReportGroup
        {
            public MedulaDontSendProcedureAndMaterialReport MyParentReport
            {
                get { return (MedulaDontSendProcedureAndMaterialReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField UNITPRICE { get {return Body().UNITPRICE;} }
            public TTReportField PROTOCOLNO { get {return Body().PROTOCOLNO;} }
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

                AccountTransaction.GetMedulaDontSendProcedureTrxsByDate_Class dataSet_GetMedulaDontSendProcedureTrxsByDate = ParentGroup.rsGroup.GetCurrentRecord<AccountTransaction.GetMedulaDontSendProcedureTrxsByDate_Class>(0);    
                return new object[] {(dataSet_GetMedulaDontSendProcedureTrxsByDate==null ? null : dataSet_GetMedulaDontSendProcedureTrxsByDate.Aciklama)};
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
                public MedulaDontSendProcedureAndMaterialReport MyParentReport
                {
                    get { return (MedulaDontSendProcedureAndMaterialReport)ParentReport; }
                }
                
                public TTReportField AMOUNT;
                public TTReportField UNITPRICE;
                public TTReportField PROTOCOLNO; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 1, 238, 6, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.Visible = EvetHayirEnum.ehHayir;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.Value = @"{#PARTX.ADET#}";

                    UNITPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 239, 1, 264, 6, false);
                    UNITPRICE.Name = "UNITPRICE";
                    UNITPRICE.Visible = EvetHayirEnum.ehHayir;
                    UNITPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNITPRICE.TextFormat = @"#,##0.#0";
                    UNITPRICE.Value = @"{#PARTX.TUTAR#}";

                    PROTOCOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 265, 0, 290, 5, false);
                    PROTOCOLNO.Name = "PROTOCOLNO";
                    PROTOCOLNO.Visible = EvetHayirEnum.ehHayir;
                    PROTOCOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOCOLNO.Value = @"{#PARTX.PROTOCOLNO#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    AccountTransaction.GetMedulaDontSendProcedureTrxsByDate_Class dataset_GetMedulaDontSendProcedureTrxsByDate = MyParentReport.PARTX.rsGroup.GetCurrentRecord<AccountTransaction.GetMedulaDontSendProcedureTrxsByDate_Class>(0);
                    AMOUNT.CalcValue = (dataset_GetMedulaDontSendProcedureTrxsByDate != null ? Globals.ToStringCore(dataset_GetMedulaDontSendProcedureTrxsByDate.Adet) : "");
                    UNITPRICE.CalcValue = (dataset_GetMedulaDontSendProcedureTrxsByDate != null ? Globals.ToStringCore(dataset_GetMedulaDontSendProcedureTrxsByDate.Tutar) : "");
                    PROTOCOLNO.CalcValue = (dataset_GetMedulaDontSendProcedureTrxsByDate != null ? Globals.ToStringCore(dataset_GetMedulaDontSendProcedureTrxsByDate.Protocolno) : "");
                    return new TTReportObject[] { AMOUNT,UNITPRICE,PROTOCOLNO};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    ((MedulaDontSendProcedureAndMaterialReport)ParentReport).amount += Convert.ToDouble(AMOUNT.CalcValue);
            ((MedulaDontSendProcedureAndMaterialReport)ParentReport).price += Convert.ToDouble(UNITPRICE.CalcValue) * Convert.ToDouble(AMOUNT.CalcValue);
            ((MedulaDontSendProcedureAndMaterialReport)ParentReport).totalAmount += Convert.ToDouble(AMOUNT.CalcValue);
            ((MedulaDontSendProcedureAndMaterialReport)ParentReport).totalPrice += Convert.ToDouble(UNITPRICE.CalcValue) * Convert.ToDouble(AMOUNT.CalcValue);
            
            if(((MedulaDontSendProcedureAndMaterialReport)ParentReport).RuntimeParameters.SHOWPROTOCOLNO == true)
            {
                string protocolNoControl = " " + PROTOCOLNO.CalcValue + ",";
                string totalProtocolNo = ((MedulaDontSendProcedureAndMaterialReport)ParentReport).protocolNo;
                if(!totalProtocolNo.Contains(protocolNoControl))
                    ((MedulaDontSendProcedureAndMaterialReport)ParentReport).protocolNo += PROTOCOLNO.CalcValue + ", ";
            }
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class PARTEGroup : TTReportGroup
        {
            public MedulaDontSendProcedureAndMaterialReport MyParentReport
            {
                get { return (MedulaDontSendProcedureAndMaterialReport)ParentReport; }
            }

            new public PARTEGroupHeader Header()
            {
                return (PARTEGroupHeader)_header;
            }

            new public PARTEGroupFooter Footer()
            {
                return (PARTEGroupFooter)_footer;
            }

            public TTReportField NewField1112311 { get {return Header().NewField1112311;} }
            public PARTEGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTEGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTEGroupHeader(this);
                _footer = new PARTEGroupFooter(this);

            }

            public partial class PARTEGroupHeader : TTReportSection
            {
                public MedulaDontSendProcedureAndMaterialReport MyParentReport
                {
                    get { return (MedulaDontSendProcedureAndMaterialReport)ParentReport; }
                }
                
                public TTReportField NewField1112311; 
                public PARTEGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 9;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1112311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 4, 38, 9, false);
                    NewField1112311.Name = "NewField1112311";
                    NewField1112311.TextFont.Size = 8;
                    NewField1112311.TextFont.Bold = true;
                    NewField1112311.TextFont.Underline = true;
                    NewField1112311.TextFont.CharSet = 162;
                    NewField1112311.Value = @"İLAÇLAR";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1112311.CalcValue = NewField1112311.Value;
                    return new TTReportObject[] { NewField1112311};
                }

                public override void RunScript()
                {
#region PARTE HEADER_Script
                    ((MedulaDontSendProcedureAndMaterialReport)ParentReport).totalAmount = 0;
            ((MedulaDontSendProcedureAndMaterialReport)ParentReport).totalPrice = 0;
#endregion PARTE HEADER_Script
                }
            }
            public partial class PARTEGroupFooter : TTReportSection
            {
                public MedulaDontSendProcedureAndMaterialReport MyParentReport
                {
                    get { return (MedulaDontSendProcedureAndMaterialReport)ParentReport; }
                }
                 
                public PARTEGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 4;
                    IsVisible = EvetHayirEnum.ehHayir;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTEGroup PARTE;

        public partial class PARTFGroup : TTReportGroup
        {
            public MedulaDontSendProcedureAndMaterialReport MyParentReport
            {
                get { return (MedulaDontSendProcedureAndMaterialReport)ParentReport; }
            }

            new public PARTFGroupHeader Header()
            {
                return (PARTFGroupHeader)_header;
            }

            new public PARTFGroupFooter Footer()
            {
                return (PARTFGroupFooter)_footer;
            }

            public TTReportField NewField111211 { get {return Header().NewField111211;} }
            public TTReportShape NewLine1111 { get {return Header().NewLine1111;} }
            public TTReportField NewField11211 { get {return Header().NewField11211;} }
            public TTReportField NewField113211 { get {return Header().NewField113211;} }
            public TTReportField NewField11122211 { get {return Header().NewField11122211;} }
            public TTReportField NewField111222111 { get {return Header().NewField111222111;} }
            public TTReportField NewField111121111 { get {return Footer().NewField111121111;} }
            public TTReportShape NewLine11111 { get {return Footer().NewLine11111;} }
            public TTReportField ILACADET { get {return Footer().ILACADET;} }
            public TTReportField ILACTUTAR { get {return Footer().ILACTUTAR;} }
            public PARTFGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTFGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTFGroupHeader(this);
                _footer = new PARTFGroupFooter(this);

            }

            public partial class PARTFGroupHeader : TTReportSection
            {
                public MedulaDontSendProcedureAndMaterialReport MyParentReport
                {
                    get { return (MedulaDontSendProcedureAndMaterialReport)ParentReport; }
                }
                
                public TTReportField NewField111211;
                public TTReportShape NewLine1111;
                public TTReportField NewField11211;
                public TTReportField NewField113211;
                public TTReportField NewField11122211;
                public TTReportField NewField111222111; 
                public PARTFGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 6;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 1, 178, 5, false);
                    NewField111211.Name = "NewField111211";
                    NewField111211.TextFont.Size = 8;
                    NewField111211.TextFont.Bold = true;
                    NewField111211.TextFont.CharSet = 162;
                    NewField111211.Value = @"Açıklama";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 6, 206, 6, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 1, 36, 5, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.TextFont.Size = 8;
                    NewField11211.TextFont.Bold = true;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @"Kod";

                    NewField113211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 1, 17, 5, false);
                    NewField113211.Name = "NewField113211";
                    NewField113211.TextFont.Size = 8;
                    NewField113211.TextFont.Bold = true;
                    NewField113211.TextFont.CharSet = 162;
                    NewField113211.Value = @"Sıra No";

                    NewField11122211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 1, 187, 5, false);
                    NewField11122211.Name = "NewField11122211";
                    NewField11122211.TextFont.Size = 8;
                    NewField11122211.TextFont.Bold = true;
                    NewField11122211.TextFont.CharSet = 162;
                    NewField11122211.Value = @"Adet";

                    NewField111222111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 1, 205, 5, false);
                    NewField111222111.Name = "NewField111222111";
                    NewField111222111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField111222111.TextFont.Size = 8;
                    NewField111222111.TextFont.Bold = true;
                    NewField111222111.TextFont.CharSet = 162;
                    NewField111222111.Value = @"Tutar";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111211.CalcValue = NewField111211.Value;
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField113211.CalcValue = NewField113211.Value;
                    NewField11122211.CalcValue = NewField11122211.Value;
                    NewField111222111.CalcValue = NewField111222111.Value;
                    return new TTReportObject[] { NewField111211,NewField11211,NewField113211,NewField11122211,NewField111222111};
                }
            }
            public partial class PARTFGroupFooter : TTReportSection
            {
                public MedulaDontSendProcedureAndMaterialReport MyParentReport
                {
                    get { return (MedulaDontSendProcedureAndMaterialReport)ParentReport; }
                }
                
                public TTReportField NewField111121111;
                public TTReportShape NewLine11111;
                public TTReportField ILACADET;
                public TTReportField ILACTUTAR; 
                public PARTFGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 8;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField111121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 2, 178, 7, false);
                    NewField111121111.Name = "NewField111121111";
                    NewField111121111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField111121111.TextFont.Size = 8;
                    NewField111121111.TextFont.Bold = true;
                    NewField111121111.TextFont.CharSet = 162;
                    NewField111121111.Value = @"İlaç Toplam :";

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 1, 206, 1, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;

                    ILACADET = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 2, 187, 6, false);
                    ILACADET.Name = "ILACADET";
                    ILACADET.FieldType = ReportFieldTypeEnum.ftVariable;
                    ILACADET.MultiLine = EvetHayirEnum.ehEvet;
                    ILACADET.NoClip = EvetHayirEnum.ehEvet;
                    ILACADET.WordBreak = EvetHayirEnum.ehEvet;
                    ILACADET.ExpandTabs = EvetHayirEnum.ehEvet;
                    ILACADET.TextFont.Size = 8;
                    ILACADET.TextFont.CharSet = 162;
                    ILACADET.Value = @"";

                    ILACTUTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 2, 205, 6, false);
                    ILACTUTAR.Name = "ILACTUTAR";
                    ILACTUTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    ILACTUTAR.TextFormat = @"#,##0.#0";
                    ILACTUTAR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ILACTUTAR.MultiLine = EvetHayirEnum.ehEvet;
                    ILACTUTAR.NoClip = EvetHayirEnum.ehEvet;
                    ILACTUTAR.WordBreak = EvetHayirEnum.ehEvet;
                    ILACTUTAR.ExpandTabs = EvetHayirEnum.ehEvet;
                    ILACTUTAR.TextFont.Size = 8;
                    ILACTUTAR.TextFont.CharSet = 162;
                    ILACTUTAR.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111121111.CalcValue = NewField111121111.Value;
                    ILACADET.CalcValue = @"";
                    ILACTUTAR.CalcValue = @"";
                    return new TTReportObject[] { NewField111121111,ILACADET,ILACTUTAR};
                }

                public override void RunScript()
                {
#region PARTF FOOTER_Script
                    ILACADET.CalcValue = (((MedulaDontSendProcedureAndMaterialReport)ParentReport).totalAmount).ToString() ;
            ILACTUTAR.CalcValue = (((MedulaDontSendProcedureAndMaterialReport)ParentReport).totalPrice).ToString() ;
            ((MedulaDontSendProcedureAndMaterialReport)ParentReport).totalAmount = 0;
            ((MedulaDontSendProcedureAndMaterialReport)ParentReport).totalPrice = 0;
#endregion PARTF FOOTER_Script
                }
            }

        }

        public PARTFGroup PARTF;

        public partial class PARTYGroup : TTReportGroup
        {
            public MedulaDontSendProcedureAndMaterialReport MyParentReport
            {
                get { return (MedulaDontSendProcedureAndMaterialReport)ParentReport; }
            }

            new public PARTYGroupHeader Header()
            {
                return (PARTYGroupHeader)_header;
            }

            new public PARTYGroupFooter Footer()
            {
                return (PARTYGroupFooter)_footer;
            }

            public TTReportField ACIKLAMA { get {return Footer().ACIKLAMA;} }
            public TTReportField KOD { get {return Footer().KOD;} }
            public TTReportField SIRANO { get {return Footer().SIRANO;} }
            public TTReportField ADET { get {return Footer().ADET;} }
            public TTReportField TUTAR { get {return Footer().TUTAR;} }
            public TTReportField PROTOCOLNO { get {return Footer().PROTOCOLNO;} }
            public TTReportField PROTOCOLNOLABEL { get {return Footer().PROTOCOLNOLABEL;} }
            public TTReportShape PROTOCOLNOLINE { get {return Footer().PROTOCOLNOLINE;} }
            public PARTYGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTYGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<AccountTransaction.GetMedulaDontSendDrugTrxsByDate_Class>("GetMedulaDontSendDrugTrxsByDate2", AccountTransaction.GetMedulaDontSendDrugTrxsByDate((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(List<Guid>) MyParentReport.RuntimeParameters.BRANCH,(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.BRANCHFLAG)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTYGroupHeader(this);
                _footer = new PARTYGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTYGroupHeader : TTReportSection
            {
                public MedulaDontSendProcedureAndMaterialReport MyParentReport
                {
                    get { return (MedulaDontSendProcedureAndMaterialReport)ParentReport; }
                }
                 
                public PARTYGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 3;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                

                public override void RunScript()
                {
#region PARTY HEADER_Script
                    ((MedulaDontSendProcedureAndMaterialReport)ParentReport).amount = 0;
            ((MedulaDontSendProcedureAndMaterialReport)ParentReport).price = 0;
            ((MedulaDontSendProcedureAndMaterialReport)ParentReport).protocolNo = " ";
#endregion PARTY HEADER_Script
                }
            }
            public partial class PARTYGroupFooter : TTReportSection
            {
                public MedulaDontSendProcedureAndMaterialReport MyParentReport
                {
                    get { return (MedulaDontSendProcedureAndMaterialReport)ParentReport; }
                }
                
                public TTReportField ACIKLAMA;
                public TTReportField KOD;
                public TTReportField SIRANO;
                public TTReportField ADET;
                public TTReportField TUTAR;
                public TTReportField PROTOCOLNO;
                public TTReportField PROTOCOLNOLABEL;
                public TTReportShape PROTOCOLNOLINE; 
                public PARTYGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 11;
                    RepeatCount = 0;
                    
                    ACIKLAMA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 1, 178, 5, false);
                    ACIKLAMA.Name = "ACIKLAMA";
                    ACIKLAMA.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACIKLAMA.TextFont.Size = 8;
                    ACIKLAMA.TextFont.CharSet = 162;
                    ACIKLAMA.Value = @"{#ACIKLAMA#}";

                    KOD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 1, 36, 5, false);
                    KOD.Name = "KOD";
                    KOD.FieldType = ReportFieldTypeEnum.ftVariable;
                    KOD.MultiLine = EvetHayirEnum.ehEvet;
                    KOD.NoClip = EvetHayirEnum.ehEvet;
                    KOD.WordBreak = EvetHayirEnum.ehEvet;
                    KOD.ExpandTabs = EvetHayirEnum.ehEvet;
                    KOD.TextFont.Size = 8;
                    KOD.TextFont.CharSet = 162;
                    KOD.Value = @"{#KOD#}";

                    SIRANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 1, 17, 5, false);
                    SIRANO.Name = "SIRANO";
                    SIRANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIRANO.MultiLine = EvetHayirEnum.ehEvet;
                    SIRANO.NoClip = EvetHayirEnum.ehEvet;
                    SIRANO.WordBreak = EvetHayirEnum.ehEvet;
                    SIRANO.ExpandTabs = EvetHayirEnum.ehEvet;
                    SIRANO.TextFont.Size = 8;
                    SIRANO.TextFont.CharSet = 162;
                    SIRANO.Value = @"{@groupcounter@}";

                    ADET = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 1, 187, 5, false);
                    ADET.Name = "ADET";
                    ADET.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADET.MultiLine = EvetHayirEnum.ehEvet;
                    ADET.NoClip = EvetHayirEnum.ehEvet;
                    ADET.WordBreak = EvetHayirEnum.ehEvet;
                    ADET.ExpandTabs = EvetHayirEnum.ehEvet;
                    ADET.TextFont.Size = 8;
                    ADET.TextFont.CharSet = 162;
                    ADET.Value = @"";

                    TUTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 1, 205, 5, false);
                    TUTAR.Name = "TUTAR";
                    TUTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    TUTAR.TextFormat = @"#,##0.#0";
                    TUTAR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TUTAR.MultiLine = EvetHayirEnum.ehEvet;
                    TUTAR.NoClip = EvetHayirEnum.ehEvet;
                    TUTAR.WordBreak = EvetHayirEnum.ehEvet;
                    TUTAR.ExpandTabs = EvetHayirEnum.ehEvet;
                    TUTAR.TextFont.Size = 8;
                    TUTAR.TextFont.CharSet = 162;
                    TUTAR.Value = @"";

                    PROTOCOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 6, 205, 10, false);
                    PROTOCOLNO.Name = "PROTOCOLNO";
                    PROTOCOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOCOLNO.MultiLine = EvetHayirEnum.ehEvet;
                    PROTOCOLNO.NoClip = EvetHayirEnum.ehEvet;
                    PROTOCOLNO.WordBreak = EvetHayirEnum.ehEvet;
                    PROTOCOLNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    PROTOCOLNO.TextFont.Size = 8;
                    PROTOCOLNO.TextFont.CharSet = 162;
                    PROTOCOLNO.Value = @"";

                    PROTOCOLNOLABEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 6, 25, 10, false);
                    PROTOCOLNOLABEL.Name = "PROTOCOLNOLABEL";
                    PROTOCOLNOLABEL.TextFont.Size = 8;
                    PROTOCOLNOLABEL.TextFont.Bold = true;
                    PROTOCOLNOLABEL.TextFont.CharSet = 162;
                    PROTOCOLNOLABEL.Value = @"Protokol No :";

                    PROTOCOLNOLINE = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 0, 206, 0, false);
                    PROTOCOLNOLINE.Name = "PROTOCOLNOLINE";
                    PROTOCOLNOLINE.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    AccountTransaction.GetMedulaDontSendDrugTrxsByDate_Class dataset_GetMedulaDontSendDrugTrxsByDate2 = ParentGroup.rsGroup.GetCurrentRecord<AccountTransaction.GetMedulaDontSendDrugTrxsByDate_Class>(0);
                    ACIKLAMA.CalcValue = (dataset_GetMedulaDontSendDrugTrxsByDate2 != null ? Globals.ToStringCore(dataset_GetMedulaDontSendDrugTrxsByDate2.Aciklama) : "");
                    KOD.CalcValue = (dataset_GetMedulaDontSendDrugTrxsByDate2 != null ? Globals.ToStringCore(dataset_GetMedulaDontSendDrugTrxsByDate2.Kod) : "");
                    SIRANO.CalcValue = ParentGroup.GroupCounter.ToString();
                    ADET.CalcValue = @"";
                    TUTAR.CalcValue = @"";
                    PROTOCOLNO.CalcValue = @"";
                    PROTOCOLNOLABEL.CalcValue = PROTOCOLNOLABEL.Value;
                    return new TTReportObject[] { ACIKLAMA,KOD,SIRANO,ADET,TUTAR,PROTOCOLNO,PROTOCOLNOLABEL};
                }

                public override void RunScript()
                {
#region PARTY FOOTER_Script
                    ADET.CalcValue = (((MedulaDontSendProcedureAndMaterialReport)ParentReport).amount).ToString();
            TUTAR.CalcValue = (((MedulaDontSendProcedureAndMaterialReport)ParentReport).price).ToString() ;
            if(((MedulaDontSendProcedureAndMaterialReport)ParentReport).RuntimeParameters.SHOWPROTOCOLNO == true)
            {
                string protocolNo = ((MedulaDontSendProcedureAndMaterialReport)ParentReport).protocolNo ;
                PROTOCOLNO.CalcValue = protocolNo.Substring(0, protocolNo.Length - 2);
                PROTOCOLNO.Visible = EvetHayirEnum.ehEvet;
                PROTOCOLNOLABEL.Visible = EvetHayirEnum.ehEvet;
                PROTOCOLNOLINE.Visible = EvetHayirEnum.ehEvet;
            }
            else
            {
                PROTOCOLNO.Visible = EvetHayirEnum.ehHayir;
                PROTOCOLNOLABEL.Visible = EvetHayirEnum.ehHayir;
                PROTOCOLNOLINE.Visible = EvetHayirEnum.ehHayir;
            }
#endregion PARTY FOOTER_Script
                }
            }

        }

        public PARTYGroup PARTY;

        public partial class PARTDGroup : TTReportGroup
        {
            public MedulaDontSendProcedureAndMaterialReport MyParentReport
            {
                get { return (MedulaDontSendProcedureAndMaterialReport)ParentReport; }
            }

            new public PARTDGroupBody Body()
            {
                return (PARTDGroupBody)_body;
            }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField UNITPRICE { get {return Body().UNITPRICE;} }
            public TTReportField PROTOCOLNO { get {return Body().PROTOCOLNO;} }
            public PARTDGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTDGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                AccountTransaction.GetMedulaDontSendDrugTrxsByDate_Class dataSet_GetMedulaDontSendDrugTrxsByDate2 = ParentGroup.rsGroup.GetCurrentRecord<AccountTransaction.GetMedulaDontSendDrugTrxsByDate_Class>(0);    
                return new object[] {(dataSet_GetMedulaDontSendDrugTrxsByDate2==null ? null : dataSet_GetMedulaDontSendDrugTrxsByDate2.Aciklama)};
            }
            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new PARTDGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class PARTDGroupBody : TTReportSection
            {
                public MedulaDontSendProcedureAndMaterialReport MyParentReport
                {
                    get { return (MedulaDontSendProcedureAndMaterialReport)ParentReport; }
                }
                
                public TTReportField AMOUNT;
                public TTReportField UNITPRICE;
                public TTReportField PROTOCOLNO; 
                public PARTDGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 1, 239, 6, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.Visible = EvetHayirEnum.ehHayir;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.Value = @"{#PARTY.ADET#}";

                    UNITPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 240, 1, 265, 6, false);
                    UNITPRICE.Name = "UNITPRICE";
                    UNITPRICE.Visible = EvetHayirEnum.ehHayir;
                    UNITPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNITPRICE.TextFormat = @"#,##0.#0";
                    UNITPRICE.Value = @"{#PARTY.TUTAR#}";

                    PROTOCOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 266, 1, 291, 6, false);
                    PROTOCOLNO.Name = "PROTOCOLNO";
                    PROTOCOLNO.Visible = EvetHayirEnum.ehHayir;
                    PROTOCOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOCOLNO.Value = @"{#PARTY.PROTOCOLNO#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    AccountTransaction.GetMedulaDontSendDrugTrxsByDate_Class dataset_GetMedulaDontSendDrugTrxsByDate2 = MyParentReport.PARTY.rsGroup.GetCurrentRecord<AccountTransaction.GetMedulaDontSendDrugTrxsByDate_Class>(0);
                    AMOUNT.CalcValue = (dataset_GetMedulaDontSendDrugTrxsByDate2 != null ? Globals.ToStringCore(dataset_GetMedulaDontSendDrugTrxsByDate2.Adet) : "");
                    UNITPRICE.CalcValue = (dataset_GetMedulaDontSendDrugTrxsByDate2 != null ? Globals.ToStringCore(dataset_GetMedulaDontSendDrugTrxsByDate2.Tutar) : "");
                    PROTOCOLNO.CalcValue = (dataset_GetMedulaDontSendDrugTrxsByDate2 != null ? Globals.ToStringCore(dataset_GetMedulaDontSendDrugTrxsByDate2.Protocolno) : "");
                    return new TTReportObject[] { AMOUNT,UNITPRICE,PROTOCOLNO};
                }

                public override void RunScript()
                {
#region PARTD BODY_Script
                    ((MedulaDontSendProcedureAndMaterialReport)ParentReport).amount += Convert.ToDouble(AMOUNT.CalcValue);
            ((MedulaDontSendProcedureAndMaterialReport)ParentReport).price += Convert.ToDouble(UNITPRICE.CalcValue) * Convert.ToDouble(AMOUNT.CalcValue);
            ((MedulaDontSendProcedureAndMaterialReport)ParentReport).totalAmount += Convert.ToDouble(AMOUNT.CalcValue);
            ((MedulaDontSendProcedureAndMaterialReport)ParentReport).totalPrice += Convert.ToDouble(UNITPRICE.CalcValue) * Convert.ToDouble(AMOUNT.CalcValue);
            
            if(((MedulaDontSendProcedureAndMaterialReport)ParentReport).RuntimeParameters.SHOWPROTOCOLNO == true)
            {
                string protocolNoControl = " " + PROTOCOLNO.CalcValue + ",";
                string totalProtocolNo = ((MedulaDontSendProcedureAndMaterialReport)ParentReport).protocolNo;
                if(!totalProtocolNo.Contains(protocolNoControl))
                    ((MedulaDontSendProcedureAndMaterialReport)ParentReport).protocolNo += PROTOCOLNO.CalcValue + ", ";
            }
#endregion PARTD BODY_Script
                }
            }

        }

        public PARTDGroup PARTD;

        public partial class PARTHGroup : TTReportGroup
        {
            public MedulaDontSendProcedureAndMaterialReport MyParentReport
            {
                get { return (MedulaDontSendProcedureAndMaterialReport)ParentReport; }
            }

            new public PARTHGroupHeader Header()
            {
                return (PARTHGroupHeader)_header;
            }

            new public PARTHGroupFooter Footer()
            {
                return (PARTHGroupFooter)_footer;
            }

            public TTReportField NewField11132111 { get {return Header().NewField11132111;} }
            public PARTHGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTHGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTHGroupHeader(this);
                _footer = new PARTHGroupFooter(this);

            }

            public partial class PARTHGroupHeader : TTReportSection
            {
                public MedulaDontSendProcedureAndMaterialReport MyParentReport
                {
                    get { return (MedulaDontSendProcedureAndMaterialReport)ParentReport; }
                }
                
                public TTReportField NewField11132111; 
                public PARTHGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 10;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField11132111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 4, 38, 9, false);
                    NewField11132111.Name = "NewField11132111";
                    NewField11132111.TextFont.Size = 8;
                    NewField11132111.TextFont.Bold = true;
                    NewField11132111.TextFont.Underline = true;
                    NewField11132111.TextFont.CharSet = 162;
                    NewField11132111.Value = @"MALZEMELER";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11132111.CalcValue = NewField11132111.Value;
                    return new TTReportObject[] { NewField11132111};
                }
            }
            public partial class PARTHGroupFooter : TTReportSection
            {
                public MedulaDontSendProcedureAndMaterialReport MyParentReport
                {
                    get { return (MedulaDontSendProcedureAndMaterialReport)ParentReport; }
                }
                 
                public PARTHGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 4;
                    IsVisible = EvetHayirEnum.ehHayir;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTHGroup PARTH;

        public partial class PARTIGroup : TTReportGroup
        {
            public MedulaDontSendProcedureAndMaterialReport MyParentReport
            {
                get { return (MedulaDontSendProcedureAndMaterialReport)ParentReport; }
            }

            new public PARTIGroupHeader Header()
            {
                return (PARTIGroupHeader)_header;
            }

            new public PARTIGroupFooter Footer()
            {
                return (PARTIGroupFooter)_footer;
            }

            public TTReportField NewField1112111 { get {return Header().NewField1112111;} }
            public TTReportShape NewLine11111 { get {return Header().NewLine11111;} }
            public TTReportField NewField111211 { get {return Header().NewField111211;} }
            public TTReportField NewField1112311 { get {return Header().NewField1112311;} }
            public TTReportField NewField111222111 { get {return Header().NewField111222111;} }
            public TTReportField NewField1111222111 { get {return Header().NewField1111222111;} }
            public TTReportField NewField111121111 { get {return Footer().NewField111121111;} }
            public TTReportShape NewLine11112 { get {return Footer().NewLine11112;} }
            public TTReportField MALZEMEADET { get {return Footer().MALZEMEADET;} }
            public TTReportField MALZEMETUTAR { get {return Footer().MALZEMETUTAR;} }
            public PARTIGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTIGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTIGroupHeader(this);
                _footer = new PARTIGroupFooter(this);

            }

            public partial class PARTIGroupHeader : TTReportSection
            {
                public MedulaDontSendProcedureAndMaterialReport MyParentReport
                {
                    get { return (MedulaDontSendProcedureAndMaterialReport)ParentReport; }
                }
                
                public TTReportField NewField1112111;
                public TTReportShape NewLine11111;
                public TTReportField NewField111211;
                public TTReportField NewField1112311;
                public TTReportField NewField111222111;
                public TTReportField NewField1111222111; 
                public PARTIGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 6;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField1112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 1, 178, 5, false);
                    NewField1112111.Name = "NewField1112111";
                    NewField1112111.TextFont.Size = 8;
                    NewField1112111.TextFont.Bold = true;
                    NewField1112111.TextFont.CharSet = 162;
                    NewField1112111.Value = @"Açıklama";

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 6, 206, 6, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 1, 36, 5, false);
                    NewField111211.Name = "NewField111211";
                    NewField111211.TextFont.Size = 8;
                    NewField111211.TextFont.Bold = true;
                    NewField111211.TextFont.CharSet = 162;
                    NewField111211.Value = @"Kod";

                    NewField1112311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 1, 17, 5, false);
                    NewField1112311.Name = "NewField1112311";
                    NewField1112311.TextFont.Size = 8;
                    NewField1112311.TextFont.Bold = true;
                    NewField1112311.TextFont.CharSet = 162;
                    NewField1112311.Value = @"Sıra No";

                    NewField111222111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 1, 187, 5, false);
                    NewField111222111.Name = "NewField111222111";
                    NewField111222111.TextFont.Size = 8;
                    NewField111222111.TextFont.Bold = true;
                    NewField111222111.TextFont.CharSet = 162;
                    NewField111222111.Value = @"Adet";

                    NewField1111222111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 1, 205, 5, false);
                    NewField1111222111.Name = "NewField1111222111";
                    NewField1111222111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField1111222111.TextFont.Size = 8;
                    NewField1111222111.TextFont.Bold = true;
                    NewField1111222111.TextFont.CharSet = 162;
                    NewField1111222111.Value = @"Tutar";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1112111.CalcValue = NewField1112111.Value;
                    NewField111211.CalcValue = NewField111211.Value;
                    NewField1112311.CalcValue = NewField1112311.Value;
                    NewField111222111.CalcValue = NewField111222111.Value;
                    NewField1111222111.CalcValue = NewField1111222111.Value;
                    return new TTReportObject[] { NewField1112111,NewField111211,NewField1112311,NewField111222111,NewField1111222111};
                }
            }
            public partial class PARTIGroupFooter : TTReportSection
            {
                public MedulaDontSendProcedureAndMaterialReport MyParentReport
                {
                    get { return (MedulaDontSendProcedureAndMaterialReport)ParentReport; }
                }
                
                public TTReportField NewField111121111;
                public TTReportShape NewLine11112;
                public TTReportField MALZEMEADET;
                public TTReportField MALZEMETUTAR; 
                public PARTIGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 8;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField111121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 2, 178, 7, false);
                    NewField111121111.Name = "NewField111121111";
                    NewField111121111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField111121111.TextFont.Size = 8;
                    NewField111121111.TextFont.Bold = true;
                    NewField111121111.TextFont.CharSet = 162;
                    NewField111121111.Value = @"Malzeme Toplam :";

                    NewLine11112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 1, 206, 1, false);
                    NewLine11112.Name = "NewLine11112";
                    NewLine11112.DrawStyle = DrawStyleConstants.vbSolid;

                    MALZEMEADET = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 2, 187, 6, false);
                    MALZEMEADET.Name = "MALZEMEADET";
                    MALZEMEADET.FieldType = ReportFieldTypeEnum.ftVariable;
                    MALZEMEADET.MultiLine = EvetHayirEnum.ehEvet;
                    MALZEMEADET.NoClip = EvetHayirEnum.ehEvet;
                    MALZEMEADET.WordBreak = EvetHayirEnum.ehEvet;
                    MALZEMEADET.ExpandTabs = EvetHayirEnum.ehEvet;
                    MALZEMEADET.TextFont.Size = 8;
                    MALZEMEADET.TextFont.CharSet = 162;
                    MALZEMEADET.Value = @"";

                    MALZEMETUTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 2, 205, 6, false);
                    MALZEMETUTAR.Name = "MALZEMETUTAR";
                    MALZEMETUTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    MALZEMETUTAR.TextFormat = @"#,##0.#0";
                    MALZEMETUTAR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    MALZEMETUTAR.MultiLine = EvetHayirEnum.ehEvet;
                    MALZEMETUTAR.NoClip = EvetHayirEnum.ehEvet;
                    MALZEMETUTAR.WordBreak = EvetHayirEnum.ehEvet;
                    MALZEMETUTAR.ExpandTabs = EvetHayirEnum.ehEvet;
                    MALZEMETUTAR.TextFont.Size = 8;
                    MALZEMETUTAR.TextFont.CharSet = 162;
                    MALZEMETUTAR.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111121111.CalcValue = NewField111121111.Value;
                    MALZEMEADET.CalcValue = @"";
                    MALZEMETUTAR.CalcValue = @"";
                    return new TTReportObject[] { NewField111121111,MALZEMEADET,MALZEMETUTAR};
                }

                public override void RunScript()
                {
#region PARTI FOOTER_Script
                    MALZEMEADET.CalcValue = (((MedulaDontSendProcedureAndMaterialReport)ParentReport).totalAmount).ToString() ;
            MALZEMETUTAR.CalcValue = (((MedulaDontSendProcedureAndMaterialReport)ParentReport).totalPrice).ToString() ;
            ((MedulaDontSendProcedureAndMaterialReport)ParentReport).totalAmount = 0;
            ((MedulaDontSendProcedureAndMaterialReport)ParentReport).totalPrice = 0;
#endregion PARTI FOOTER_Script
                }
            }

        }

        public PARTIGroup PARTI;

        public partial class PARTZGroup : TTReportGroup
        {
            public MedulaDontSendProcedureAndMaterialReport MyParentReport
            {
                get { return (MedulaDontSendProcedureAndMaterialReport)ParentReport; }
            }

            new public PARTZGroupHeader Header()
            {
                return (PARTZGroupHeader)_header;
            }

            new public PARTZGroupFooter Footer()
            {
                return (PARTZGroupFooter)_footer;
            }

            public TTReportField ACIKLAMA { get {return Footer().ACIKLAMA;} }
            public TTReportField KOD { get {return Footer().KOD;} }
            public TTReportField SIRANO { get {return Footer().SIRANO;} }
            public TTReportField ADET { get {return Footer().ADET;} }
            public TTReportField TUTAR { get {return Footer().TUTAR;} }
            public TTReportField PROTOCOLNO { get {return Footer().PROTOCOLNO;} }
            public TTReportField PROTOCOLNOLABEL { get {return Footer().PROTOCOLNOLABEL;} }
            public TTReportShape PROTOCOLNOLINE { get {return Footer().PROTOCOLNOLINE;} }
            public PARTZGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTZGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<AccountTransaction.GetMedulaDontSendMaterialTrxsByDate_Class>("GetMedulaDontSendMaterialTrxsByDate2", AccountTransaction.GetMedulaDontSendMaterialTrxsByDate((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(List<Guid>) MyParentReport.RuntimeParameters.BRANCH,(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.BRANCHFLAG)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTZGroupHeader(this);
                _footer = new PARTZGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTZGroupHeader : TTReportSection
            {
                public MedulaDontSendProcedureAndMaterialReport MyParentReport
                {
                    get { return (MedulaDontSendProcedureAndMaterialReport)ParentReport; }
                }
                 
                public PARTZGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 4;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                

                public override void RunScript()
                {
#region PARTZ HEADER_Script
                    ((MedulaDontSendProcedureAndMaterialReport)ParentReport).amount = 0;
            ((MedulaDontSendProcedureAndMaterialReport)ParentReport).price = 0;
            ((MedulaDontSendProcedureAndMaterialReport)ParentReport).protocolNo = " ";
#endregion PARTZ HEADER_Script
                }
            }
            public partial class PARTZGroupFooter : TTReportSection
            {
                public MedulaDontSendProcedureAndMaterialReport MyParentReport
                {
                    get { return (MedulaDontSendProcedureAndMaterialReport)ParentReport; }
                }
                
                public TTReportField ACIKLAMA;
                public TTReportField KOD;
                public TTReportField SIRANO;
                public TTReportField ADET;
                public TTReportField TUTAR;
                public TTReportField PROTOCOLNO;
                public TTReportField PROTOCOLNOLABEL;
                public TTReportShape PROTOCOLNOLINE; 
                public PARTZGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 11;
                    RepeatCount = 0;
                    
                    ACIKLAMA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 1, 178, 5, false);
                    ACIKLAMA.Name = "ACIKLAMA";
                    ACIKLAMA.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACIKLAMA.TextFont.Size = 8;
                    ACIKLAMA.TextFont.CharSet = 162;
                    ACIKLAMA.Value = @"{#ACIKLAMA#}";

                    KOD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 1, 36, 5, false);
                    KOD.Name = "KOD";
                    KOD.FieldType = ReportFieldTypeEnum.ftVariable;
                    KOD.MultiLine = EvetHayirEnum.ehEvet;
                    KOD.NoClip = EvetHayirEnum.ehEvet;
                    KOD.WordBreak = EvetHayirEnum.ehEvet;
                    KOD.ExpandTabs = EvetHayirEnum.ehEvet;
                    KOD.TextFont.Size = 8;
                    KOD.TextFont.CharSet = 162;
                    KOD.Value = @"{#KOD#}";

                    SIRANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 1, 17, 5, false);
                    SIRANO.Name = "SIRANO";
                    SIRANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIRANO.MultiLine = EvetHayirEnum.ehEvet;
                    SIRANO.NoClip = EvetHayirEnum.ehEvet;
                    SIRANO.WordBreak = EvetHayirEnum.ehEvet;
                    SIRANO.ExpandTabs = EvetHayirEnum.ehEvet;
                    SIRANO.TextFont.Size = 8;
                    SIRANO.TextFont.CharSet = 162;
                    SIRANO.Value = @"{@groupcounter@}";

                    ADET = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 1, 187, 5, false);
                    ADET.Name = "ADET";
                    ADET.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADET.MultiLine = EvetHayirEnum.ehEvet;
                    ADET.NoClip = EvetHayirEnum.ehEvet;
                    ADET.WordBreak = EvetHayirEnum.ehEvet;
                    ADET.ExpandTabs = EvetHayirEnum.ehEvet;
                    ADET.TextFont.Size = 8;
                    ADET.TextFont.CharSet = 162;
                    ADET.Value = @"";

                    TUTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 1, 205, 5, false);
                    TUTAR.Name = "TUTAR";
                    TUTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    TUTAR.TextFormat = @"#,##0.#0";
                    TUTAR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TUTAR.MultiLine = EvetHayirEnum.ehEvet;
                    TUTAR.NoClip = EvetHayirEnum.ehEvet;
                    TUTAR.WordBreak = EvetHayirEnum.ehEvet;
                    TUTAR.ExpandTabs = EvetHayirEnum.ehEvet;
                    TUTAR.TextFont.Size = 8;
                    TUTAR.TextFont.CharSet = 162;
                    TUTAR.Value = @"";

                    PROTOCOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 6, 205, 10, false);
                    PROTOCOLNO.Name = "PROTOCOLNO";
                    PROTOCOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOCOLNO.MultiLine = EvetHayirEnum.ehEvet;
                    PROTOCOLNO.NoClip = EvetHayirEnum.ehEvet;
                    PROTOCOLNO.WordBreak = EvetHayirEnum.ehEvet;
                    PROTOCOLNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    PROTOCOLNO.TextFont.Size = 8;
                    PROTOCOLNO.TextFont.CharSet = 162;
                    PROTOCOLNO.Value = @"";

                    PROTOCOLNOLABEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 6, 25, 10, false);
                    PROTOCOLNOLABEL.Name = "PROTOCOLNOLABEL";
                    PROTOCOLNOLABEL.TextFont.Size = 8;
                    PROTOCOLNOLABEL.TextFont.Bold = true;
                    PROTOCOLNOLABEL.TextFont.CharSet = 162;
                    PROTOCOLNOLABEL.Value = @"Protokol No :";

                    PROTOCOLNOLINE = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 0, 206, 0, false);
                    PROTOCOLNOLINE.Name = "PROTOCOLNOLINE";
                    PROTOCOLNOLINE.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    AccountTransaction.GetMedulaDontSendMaterialTrxsByDate_Class dataset_GetMedulaDontSendMaterialTrxsByDate2 = ParentGroup.rsGroup.GetCurrentRecord<AccountTransaction.GetMedulaDontSendMaterialTrxsByDate_Class>(0);
                    ACIKLAMA.CalcValue = (dataset_GetMedulaDontSendMaterialTrxsByDate2 != null ? Globals.ToStringCore(dataset_GetMedulaDontSendMaterialTrxsByDate2.Aciklama) : "");
                    KOD.CalcValue = (dataset_GetMedulaDontSendMaterialTrxsByDate2 != null ? Globals.ToStringCore(dataset_GetMedulaDontSendMaterialTrxsByDate2.Kod) : "");
                    SIRANO.CalcValue = ParentGroup.GroupCounter.ToString();
                    ADET.CalcValue = @"";
                    TUTAR.CalcValue = @"";
                    PROTOCOLNO.CalcValue = @"";
                    PROTOCOLNOLABEL.CalcValue = PROTOCOLNOLABEL.Value;
                    return new TTReportObject[] { ACIKLAMA,KOD,SIRANO,ADET,TUTAR,PROTOCOLNO,PROTOCOLNOLABEL};
                }

                public override void RunScript()
                {
#region PARTZ FOOTER_Script
                    ADET.CalcValue = (((MedulaDontSendProcedureAndMaterialReport)ParentReport).amount).ToString();
            TUTAR.CalcValue = (((MedulaDontSendProcedureAndMaterialReport)ParentReport).price).ToString() ;
            if(((MedulaDontSendProcedureAndMaterialReport)ParentReport).RuntimeParameters.SHOWPROTOCOLNO == true)
            {
                string protocolNo = ((MedulaDontSendProcedureAndMaterialReport)ParentReport).protocolNo ;
                PROTOCOLNO.CalcValue = protocolNo.Substring(0, protocolNo.Length - 2);
                PROTOCOLNO.Visible = EvetHayirEnum.ehEvet;
                PROTOCOLNOLABEL.Visible = EvetHayirEnum.ehEvet;
                PROTOCOLNOLINE.Visible = EvetHayirEnum.ehEvet;
            }
            else
            {
                PROTOCOLNO.Visible = EvetHayirEnum.ehHayir;
                PROTOCOLNOLABEL.Visible = EvetHayirEnum.ehHayir;
                PROTOCOLNOLINE.Visible = EvetHayirEnum.ehHayir;
            }
#endregion PARTZ FOOTER_Script
                }
            }

        }

        public PARTZGroup PARTZ;

        public partial class PARTGGroup : TTReportGroup
        {
            public MedulaDontSendProcedureAndMaterialReport MyParentReport
            {
                get { return (MedulaDontSendProcedureAndMaterialReport)ParentReport; }
            }

            new public PARTGGroupBody Body()
            {
                return (PARTGGroupBody)_body;
            }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField UNITPRICE { get {return Body().UNITPRICE;} }
            public TTReportField PROTOCOLNO { get {return Body().PROTOCOLNO;} }
            public PARTGGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTGGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                AccountTransaction.GetMedulaDontSendMaterialTrxsByDate_Class dataSet_GetMedulaDontSendMaterialTrxsByDate2 = ParentGroup.rsGroup.GetCurrentRecord<AccountTransaction.GetMedulaDontSendMaterialTrxsByDate_Class>(0);    
                return new object[] {(dataSet_GetMedulaDontSendMaterialTrxsByDate2==null ? null : dataSet_GetMedulaDontSendMaterialTrxsByDate2.Aciklama)};
            }
            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new PARTGGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class PARTGGroupBody : TTReportSection
            {
                public MedulaDontSendProcedureAndMaterialReport MyParentReport
                {
                    get { return (MedulaDontSendProcedureAndMaterialReport)ParentReport; }
                }
                
                public TTReportField AMOUNT;
                public TTReportField UNITPRICE;
                public TTReportField PROTOCOLNO; 
                public PARTGGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 1, 236, 6, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.Visible = EvetHayirEnum.ehHayir;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.Value = @"{#PARTZ.ADET#}";

                    UNITPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 237, 1, 262, 6, false);
                    UNITPRICE.Name = "UNITPRICE";
                    UNITPRICE.Visible = EvetHayirEnum.ehHayir;
                    UNITPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNITPRICE.TextFormat = @"#,##0.#0";
                    UNITPRICE.Value = @"{#PARTZ.TUTAR#}";

                    PROTOCOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 263, 1, 288, 6, false);
                    PROTOCOLNO.Name = "PROTOCOLNO";
                    PROTOCOLNO.Visible = EvetHayirEnum.ehHayir;
                    PROTOCOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOCOLNO.Value = @"{#PARTZ.PROTOCOLNO#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    AccountTransaction.GetMedulaDontSendMaterialTrxsByDate_Class dataset_GetMedulaDontSendMaterialTrxsByDate2 = MyParentReport.PARTZ.rsGroup.GetCurrentRecord<AccountTransaction.GetMedulaDontSendMaterialTrxsByDate_Class>(0);
                    AMOUNT.CalcValue = (dataset_GetMedulaDontSendMaterialTrxsByDate2 != null ? Globals.ToStringCore(dataset_GetMedulaDontSendMaterialTrxsByDate2.Adet) : "");
                    UNITPRICE.CalcValue = (dataset_GetMedulaDontSendMaterialTrxsByDate2 != null ? Globals.ToStringCore(dataset_GetMedulaDontSendMaterialTrxsByDate2.Tutar) : "");
                    PROTOCOLNO.CalcValue = (dataset_GetMedulaDontSendMaterialTrxsByDate2 != null ? Globals.ToStringCore(dataset_GetMedulaDontSendMaterialTrxsByDate2.Protocolno) : "");
                    return new TTReportObject[] { AMOUNT,UNITPRICE,PROTOCOLNO};
                }

                public override void RunScript()
                {
#region PARTG BODY_Script
                    ((MedulaDontSendProcedureAndMaterialReport)ParentReport).amount += Convert.ToDouble(AMOUNT.CalcValue);
            ((MedulaDontSendProcedureAndMaterialReport)ParentReport).price += Convert.ToDouble(UNITPRICE.CalcValue) * Convert.ToDouble(AMOUNT.CalcValue);
            ((MedulaDontSendProcedureAndMaterialReport)ParentReport).totalAmount += Convert.ToDouble(AMOUNT.CalcValue);
            ((MedulaDontSendProcedureAndMaterialReport)ParentReport).totalPrice += Convert.ToDouble(UNITPRICE.CalcValue) * Convert.ToDouble(AMOUNT.CalcValue);
            
            if(((MedulaDontSendProcedureAndMaterialReport)ParentReport).RuntimeParameters.SHOWPROTOCOLNO == true)
            {
                string protocolNoControl = " " + PROTOCOLNO.CalcValue + ",";
                string totalProtocolNo = ((MedulaDontSendProcedureAndMaterialReport)ParentReport).protocolNo;
                if(!totalProtocolNo.Contains(protocolNoControl))
                    ((MedulaDontSendProcedureAndMaterialReport)ParentReport).protocolNo += PROTOCOLNO.CalcValue + ", ";
            }
#endregion PARTG BODY_Script
                }
            }

        }

        public PARTGGroup PARTG;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public MedulaDontSendProcedureAndMaterialReport()
        {
            PARTJ = new PARTJGroup(this,"PARTJ");
            PARTA = new PARTAGroup(PARTJ,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            PARTC = new PARTCGroup(PARTB,"PARTC");
            PARTX = new PARTXGroup(PARTC,"PARTX");
            MAIN = new MAINGroup(PARTX,"MAIN");
            PARTE = new PARTEGroup(PARTA,"PARTE");
            PARTF = new PARTFGroup(PARTE,"PARTF");
            PARTY = new PARTYGroup(PARTF,"PARTY");
            PARTD = new PARTDGroup(PARTY,"PARTD");
            PARTH = new PARTHGroup(PARTA,"PARTH");
            PARTI = new PARTIGroup(PARTH,"PARTI");
            PARTZ = new PARTZGroup(PARTI,"PARTZ");
            PARTG = new PARTGGroup(PARTZ,"PARTG");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("SHOWPROTOCOLNO", "", "Protokol No Göster", @"", true, true, false, new Guid("87fa0907-eeb7-43e0-b870-8690afc73bc3"));
            reportParameter = Parameters.Add("BRANCH", "", "Branş", @"", false, true, true, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("8b28f3a9-d983-4221-a2b8-65a9dc603636");
            reportParameter = Parameters.Add("BRANCHFLAG", "", "Branş Kontrol", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("SHOWPROTOCOLNO"))
                _runtimeParameters.SHOWPROTOCOLNO = (bool?)TTObjectDefManager.Instance.DataTypes["Boolean"].ConvertValue(parameters["SHOWPROTOCOLNO"]);
            if (parameters.ContainsKey("BRANCH"))
                _runtimeParameters.BRANCH = (List<Guid>)parameters["BRANCH"];
            if (parameters.ContainsKey("BRANCHFLAG"))
                _runtimeParameters.BRANCHFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["BRANCHFLAG"]);
            Name = "MEDULADONTSENDPROCEDUREANDMATERIALREPORT";
            Caption = "Medulaya Gönderilmeyecek Hizmet ve Malzemeler Raporu";
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
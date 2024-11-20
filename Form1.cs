using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            QuestPDF.Settings.License = LicenseType.Community;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var pdf = new SamplePdf();

            var tmpInputFileName = Path.GetTempFileName();

            var tmpOutputFileName = Path.GetTempFileName();

            pdf.GeneratePdf(tmpInputFileName);




            DocumentOperation
                .LoadFile(tmpInputFileName)
                .AddAttachment(new DocumentOperation.DocumentAttachment
                {
                    Key = "factur-zugferd",
                    FilePath = "test.xml",
                    AttachmentName = "factur-x.xml",
                    MimeType = "text/xml",
                    Description = "Factur-X Invoice",
                    Relationship = DocumentOperation.DocumentAttachmentRelationship.Source,
                    CreationDate = DateTime.UtcNow,
                    ModificationDate = DateTime.UtcNow
                })
                .ExtendMetadata(System.IO.File.ReadAllText("meta.xml"))
                .Save(tmpOutputFileName);


        }
    }
}

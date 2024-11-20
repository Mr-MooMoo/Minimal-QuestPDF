using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace WinFormsApp1
{
    internal class SamplePdf : IDocument
    {

        public DocumentSettings GetSettings() => new DocumentSettings() { PdfA = true };


        private DocumentMetadata DocumentMetadata() => new DocumentMetadata()
        {
            Title = $"Invoice",
            Author = "McLovin",
            Subject = $"Invoice Nr. 123456",
            CreationDate = DateTimeOffset.Now,
            ModifiedDate = DateTimeOffset.Now,
        };


        public void Compose(IDocumentContainer container)
        {
            container
                .Page(page =>
                {
                    page.Margin(30);

                    page.Header().Element(x => x.Text("Hello World."));
                    page.Footer().PaddingHorizontal(20).PaddingTop(5).Element(x => x.Text("Bye Bye"));
                });
        }

        
    }
}

using Modelos.IntegradorCRM.Models.EF;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

public class QuestPDFService
{

   
    private List<Controle_Liberacao_ComissaoModel> Controle_Liberacao_ComissaoList;
    private string vendedor { get; set; }
    private string StartDate { get; set; }
    private string EndDate { get; set; }
  

    public QuestPDFService(List<Controle_Liberacao_ComissaoModel> comissaoList, string vendedor, string startDate, string endDate)
    {
        Controle_Liberacao_ComissaoList = comissaoList;
        this.vendedor = vendedor;
        StartDate = startDate;
        EndDate = endDate;
    }
    public void GerarPDF(string filePath, bool GerarPDFComAssinatura, string TipoRelatorio)
    {
       
        Document.Create(document =>
        {
            document.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(20);



                page.Header()
                    .Row(row =>
                    {


                        row.RelativeItem(2)
                          .BorderBottom(1)
                          .Height(70)
                          .Image("logo.png");

                        row.RelativeItem(3)
                            .BorderBottom(1)
                            .PaddingLeft(10)
                            .Height(100)
                            .Column(column =>
                            {
                                column.Item().Text($"Relatorio de Comissão {TipoRelatorio}").FontSize(20).FontColor(Colors.Blue.Medium).SemiBold();
                                column.Item().Text($"Vendedor : {vendedor}").FontSize(10);
                                column.Item().Text($"Periodo: {StartDate} - {EndDate}").FontSize(10);
                                column.Item().Text($"Geração: {DateTime.Now.ToString("dd/MM/yyyy")}").FontSize(10);
                            });
                    
                    });
                 


                page.Content()
                    .Column(col =>
                    {
                        col.Item().Text("Comissão Detalhada:").FontSize(20).Bold();
                        col.Item().Text("");
                        col.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(70);
                                columns.RelativeColumn(70);
                                columns.RelativeColumn(90);
                                columns.ConstantColumn(70);
                                columns.ConstantColumn(90);
                                columns.RelativeColumn(100);
                                columns.ConstantColumn(80);
                            });

                            table.Header(header =>
                            {
                                int sizefonte = 10;
                                int borderbottom = 3;
                                int tamanhobottom = 5;

                                header.Cell().BorderBottom(borderbottom).PaddingBottom(tamanhobottom).Text("Ped. Venda").Bold().FontColor(Colors.Orange.Accent3).FontSize(sizefonte);
                                header.Cell().BorderBottom(borderbottom).PaddingBottom(tamanhobottom).Text("Nr Nota").Bold().FontColor(Colors.Blue.Accent2).FontSize(sizefonte);
                                header.Cell().BorderBottom(borderbottom).PaddingBottom(tamanhobottom).Text("Emis. NFe").Bold().FontColor(Colors.Blue.Accent2).FontSize(sizefonte);
                                header.Cell().BorderBottom(borderbottom).PaddingBottom(tamanhobottom).Text("Doc. Receber").Bold().FontColor("#033d58").FontSize(sizefonte);
                                header.Cell().BorderBottom(borderbottom).PaddingBottom(tamanhobottom).Text("Quitação").Bold().FontColor("#033d58").FontSize(sizefonte);
                                header.Cell().BorderBottom(borderbottom).PaddingBottom(tamanhobottom).Text("Nr. Gerados").Bold().FontColor("#033d58").FontSize(sizefonte);
                                header.Cell().BorderBottom(borderbottom).PaddingBottom(tamanhobottom).Text("Comissão").Bold().FontColor(Colors.Red.Accent2).FontSize(sizefonte);
                            });


                            int i = 0;
                            foreach (var comissaoItem in Controle_Liberacao_ComissaoList)
                            {
                                string? docreceber = comissaoItem.Id_Documento_Receber == 0 ? "Avista" : comissaoItem.Id_Documento_Receber.ToString();
                                string? NrDRGerados = comissaoItem.DR_Total_Gerados == 0 ? "Sem DR" : comissaoItem.DR_Total_Gerados.ToString();
                                int sizefonte = 9;

                                table.Cell().Element(CellStyle).Text(comissaoItem.Id_Pedido_Venda.ToString()).FontSize(sizefonte);
                                table.Cell().Element(CellStyle).Text(comissaoItem.numero_documento_fiscal.ToString()).FontSize(sizefonte);
                                table.Cell().Element(CellStyle).Text(comissaoItem.data_hora_emissao_nota.Value.ToString("dd/MM/yyyy")).FontSize(sizefonte);
                                table.Cell().Element(CellStyle).Text(docreceber).FontSize(sizefonte).AlignCenter();
                                table.Cell().Element(CellStyle).Text(comissaoItem.Data_Quitacao.HasValue ? comissaoItem.Data_Quitacao.Value.ToString("dd/MM/yyyy") : "ABERTO").FontSize(sizefonte);
                                table.Cell().Element(CellStyle).AlignLeft().Text(NrDRGerados).FontSize(sizefonte);
                                table.Cell().Element(CellStyle).PaddingLeft(5).Text("R$ " + comissaoItem.Valor_Comissao_Por_Parcela.ToString("F2")).AlignRight().AlignLeft().FontSize(sizefonte);

                                IContainer CellStyle(IContainer container)
                                {
                                    var backgroundColor = i % 2 == 0
                                        ? Colors.Grey.Lighten2
                                        : Colors.Grey.Lighten5;

                                    return container
                                        .Background(backgroundColor)
                                        .PaddingVertical(1);
                                }
                                i++;
                            }

                            int tamanhobottom = 1;
                            table.Cell().BorderBottom(tamanhobottom).PaddingVertical(2);
                            table.Cell().BorderBottom(tamanhobottom).PaddingVertical(2);
                            table.Cell().BorderBottom(tamanhobottom).PaddingVertical(2);
                            table.Cell().BorderBottom(tamanhobottom).PaddingVertical(2);
                            table.Cell().BorderBottom(tamanhobottom).PaddingVertical(2);
                            table.Cell().BorderBottom(tamanhobottom).PaddingVertical(2);
                            table.Cell().BorderBottom(tamanhobottom).PaddingVertical(2);

                        });

                        decimal grandTotal = 0;
                        foreach (var product in Controle_Liberacao_ComissaoList)
                        {
                            grandTotal += product.Valor_Comissao_Por_Parcela;
                        }

                        col.Item().PaddingVertical(30).AlignRight().Text($"Valor total: R${grandTotal:F2}").Bold().FontSize(14);


                        // Rodapé manual na última página
                        if (GerarPDFComAssinatura)
                        {
                            col.Item().PaddingVertical(5).AlignCenter().Text("Assinatura do vendedor: _______________________, data do pagamento __/__/____ ").FontSize(14);
                        }

                        page.Footer()
                            .Column(col =>
                            {

                                col.Item().PaddingVertical(5).AlignCenter().Text("Relatorío Gerado Pelo Sistema CDI OminiService by CDI Software ₢").FontSize(8);
                                col.Item().AlignCenter().Text(text =>
                                {
                                    text.CurrentPageNumber();
                                    text.Span(" / ");
                                    text.TotalPages();
                                });
                            });


                    });
            });
        }).GeneratePdf(filePath);
    }
}
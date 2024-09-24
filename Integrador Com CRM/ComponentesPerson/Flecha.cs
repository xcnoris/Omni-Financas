using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Integrador_Com_CRM.ComponentesPerson
{
    public class Flecha : Control
    {
        public Flecha()
        {
            this.Size = new Size(100, 100); // Tamanho padrão do componente
        }
        
        // Propriedade para a direção 
        public enum FlechaDirecao
        {
            Cima, Baixo, Esquerda, Direita
        }

        public FlechaDirecao Direcao { get; set; } = FlechaDirecao.Direita;

        // Sobrescreve o método OnPaint para desenhar a flecha
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            // Define a cor da caneta e a largura da linha
            using (Pen pen = new Pen(Color.ForestGreen, 3))
            {
                // Definindo os pontos principais para a linha e a cabeça da flecha
                Point lineStart = Point.Empty;
                Point lineEnd = Point.Empty;
                Point[] arrowHead = null;

                // Calculando a direção e o formato da flecha
                switch (Direcao)
                {
                    case FlechaDirecao.Cima:
                        lineStart = new Point(this.Width / 2, this.Height);
                        lineEnd = new Point(this.Width / 2, 20); // Linha vertical
                        arrowHead = new Point[]
                        {
                            new Point(this.Width / 2 - 10, 20), // Base esquerda da cabeça
                            new Point(this.Width / 2 + 10, 20), // Base direita da cabeça
                            new Point(this.Width / 2, 0)        // Ponta da flecha
                        };
                        break;

                    case FlechaDirecao.Baixo:
                        lineStart = new Point(this.Width / 2, 0);
                        lineEnd = new Point(this.Width / 2, this.Height - 20); // Linha vertical
                        arrowHead = new Point[]
                        {
                            new Point(this.Width / 2 - 10, this.Height - 20),
                            new Point(this.Width / 2 + 10, this.Height - 20),
                            new Point(this.Width / 2, this.Height)
                        };
                        break;

                    case FlechaDirecao.Esquerda:
                        lineStart = new Point(this.Width, this.Height / 2);
                        lineEnd = new Point(20, this.Height / 2); // Linha Horizontal
                        arrowHead = new Point[]
                        {
                            new Point(20, this.Height / 2 - 10),
                            new Point(20, this.Height / 2 + 10),
                            new Point(0, this.Height / 2)
                        };
                        break;

                    case FlechaDirecao.Direita:
                        lineStart = new Point(0, this.Height / 2);
                        lineEnd = new Point(this.Width - 20, this.Height / 2); // Linha horizontal
                        arrowHead = new Point[]
                        {
                            new Point(this.Width - 20, this.Height / 2 - 10),
                            new Point(this.Width - 20, this.Height / 2 + 10),
                            new Point(this.Width, this.Height / 2)
                        };
                        break;
                }

                // Desenha a linha principal da flecha
                g.DrawLine(pen, lineStart, lineEnd);

                // Desenha a linha principal da flecha
                if (arrowHead != null)
                    g.FillPolygon(Brushes.ForestGreen, arrowHead);
            }
        }
    }
}

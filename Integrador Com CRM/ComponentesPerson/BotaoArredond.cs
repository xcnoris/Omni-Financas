using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador_Com_CRM.ComponentesPerson
{
    public partial class BotaoArredond : Button
    {
        public BotaoArredond()
        {
            InitializeComponent();
        }

        public BotaoArredond(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private int _raioCanto = 20;

        public int RaioCanto
        {
            get { return _raioCanto; }
            set { _raioCanto = value; this.Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            // Configurar o modo de suavização para antialias para melhor qualidade
            pevent.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            //  Criar o caminho para o retângulo arredondado
            GraphicsPath caminho = new GraphicsPath();
            caminho.AddArc(new Rectangle(0, 0, _raioCanto, _raioCanto), 180, 90);
            caminho.AddArc(new Rectangle(this.Width - _raioCanto, 0, _raioCanto, _raioCanto), 270, 90);
            caminho.AddArc(new Rectangle(this.Width - _raioCanto, this.Height - _raioCanto, _raioCanto, _raioCanto), 0, 90);
            caminho.AddArc(new Rectangle(0, this.Height - _raioCanto, _raioCanto, _raioCanto), 90, 90);
            caminho.CloseAllFigures();

            // Definir a região para o retângulo arredondado
            this.Region = new Region(caminho);

            // Desenhar o fundo do botão
            using (SolidBrush brush = new SolidBrush(this.BackColor))
            {
                pevent.Graphics.FillPath(brush, caminho);
            }

            // Desenhar o texto do botão
            TextRenderer.DrawText(pevent.Graphics, this.Text, this.Font, this.ClientRectangle, this.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
    }
}

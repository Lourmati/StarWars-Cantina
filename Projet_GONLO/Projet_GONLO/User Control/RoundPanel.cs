using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet_GONLO
{
    public class RoundPanel : Panel
    {
        Pen pen;
        float penWidth = 2.0f;
        int _edge = 20;
        Color _borderColor = Color.White;

        public int Edge
        {
            get
            {
                return _edge;
            }
            set
            {
                _edge = value;
                Invalidate();
            }
        }

        public Color BorderColor
        {
            get
            {
                return _borderColor;
            }
            set
            {
                _borderColor = value;
                pen = new Pen(_borderColor, penWidth);
                Invalidate();
            }
        }

        public RoundPanel()
        {
            pen = new Pen(_borderColor, penWidth);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            ExtendedDraw(e);
        }

        private void ExtendedDraw(object e)
        {
            
            GraphicsPath path = new GraphicsPath();

            path.StartFigure();
            path.StartFigure();
            path.AddArc(GetLeftUpper(Edge), 180, 90);
            path.AddLine(Edge, 0, Width - Edge, 0);
            path.AddArc(GetRightUpper(Edge), 270, 90);
            path.AddLine(Width, Edge, Width, Height - Edge);
            path.AddArc(GetRightLower(Edge), 0, 90);
            path.AddLine(Width - Edge, Height, Edge, Height);
            path.AddArc(GetLeftLower(Edge), 90, 90);
            path.AddLine(0, Height - Edge, 0, Edge);
            path.CloseFigure();

            Region = new Region(path);
        }

        private RectangleF GetLeftLower(int edge)
        {
            return new Rectangle(0, Height - edge, edge, edge);
        }

        private RectangleF GetRightLower(int edge)
        {
            return new Rectangle(Width - edge, Height - edge, edge, edge);
        }

        private RectangleF GetRightUpper(int edge)
        {
            return new Rectangle(Width - edge, 0, edge, edge);
        }

        private RectangleF GetLeftUpper(int edge)
        {
            return new Rectangle(0, 0, edge, edge);
        }

        private void DrawSingleBorder(Graphics graphics)
        {
            graphics.DrawArc(pen, new Rectangle(0, 0, Edge, Edge), 180, 90);
            graphics.DrawArc(pen, new Rectangle(Width - Edge - 1, -1, Edge, Edge), 270, 90);
            graphics.DrawArc(pen, new Rectangle(Width - Edge - 1, Height - Edge - 1, Edge, Edge), 0, 90);
            graphics.DrawArc(pen, new Rectangle(0, Height - Edge - 1, Edge, Edge), 90, 90);

            graphics.DrawRectangle(pen, 0.0F, 0.0F, Width - 1, Height - 1);
        }

        private void DrawBorder(Graphics graphics)
        {
            DrawSingleBorder(graphics);
        }
    }
}

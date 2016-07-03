using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Lextm.SharpSnmpLib
{
    internal class VS2015DarkToolStripRenderer : ToolStripProfessionalRenderer
    {
        private static readonly VS2015DarkColorTable CustomColorTable = new VS2015DarkColorTable();

        public VS2015DarkToolStripRenderer()
            : base(CustomColorTable)
        {
        }

        public void RefreshToolStrips()
        {
            ToolStripRenderer old = ToolStripManager.Renderer;
            if (old != null && ToolStripManager.RenderMode == ToolStripManagerRenderMode.Custom)
            {
                ToolStripManager.RenderMode = ToolStripManagerRenderMode.Professional;
                ToolStripManager.Renderer = old;
            }
        }

        /// <summary>
        /// Gets the color palette used for painting.
        /// </summary>
        /// <value></value>
        /// <returns>The <see cref="CustomColorTable"/> used for painting.</returns>
        public new VS2015DarkColorTable ColorTable
        {
            get { return CustomColorTable; }
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            if(e.Item.Enabled)
                e.TextColor = ColorTable.MenuItemText;
            base.OnRenderItemText(e);
        }

        protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
        {
            Rectangle rect = new Rectangle(6, 5, 12, 12);
            SolidBrush brush = new SolidBrush(ColorTable.MenuItemSelectedGradientBegin);
            e.Graphics.FillRectangle(brush, e.ImageRectangle);
            if (e.Item.Selected)
                e.Graphics.DrawImage(WeifenLuo.WinFormsUI.ThemeVS2015Dark.Resources.Menu_Checkmark_Highlight, rect);
            else
                e.Graphics.DrawImage(WeifenLuo.WinFormsUI.ThemeVS2015Dark.Resources.Menu_Checkmark, rect);
            
        }

        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            e.ArrowColor = e.Item.Selected ? ColorTable.ButtonPressedGradientBegin : ColorTable.MenuItemText;
            base.OnRenderArrow(e);
        }
    }
}
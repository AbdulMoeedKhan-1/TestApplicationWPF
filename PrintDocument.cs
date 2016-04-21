using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplicationWPF
{
    public class MyPrintDocument : RadPrintDocument
    {
        public string LeftUpperText { get; set; }
        public Font LeftUpperFont { get; set; }
        public string LeftMiddleText { get; set; }
        public Font LeftMiddleFont { get; set; }
        public string LeftLowerText { get; set; }
        public Font LeftLowerFont { get; set; }
        protected override void PrintHeader(System.Drawing.Printing.PrintPageEventArgs args)
        {
            base.PrintHeader(args);
            Rectangle headerRect = new Rectangle(args.MarginBounds.Location, new Size(args.MarginBounds.Width, this.HeaderHeight));
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Near;
            args.Graphics.DrawString(this.LeftUpperText, this.LeftUpperFont, Brushes.Red, new Rectangle(headerRect.X, headerRect.Y, headerRect.Width / 3, headerRect.Height / 3), stringFormat);
            args.Graphics.DrawString(this.LeftMiddleText, this.LeftMiddleFont, Brushes.Blue, new Rectangle(headerRect.X, headerRect.Y + headerRect.Height / 3, headerRect.Width / 3, headerRect.Height / 3), stringFormat);
            args.Graphics.DrawString(this.LeftLowerText, this.LeftLowerFont, Brushes.Green, new Rectangle(headerRect.X, headerRect.Y + (headerRect.Height) * 2 / 3, headerRect.Width / 3, headerRect.Height / 3), stringFormat);
            args.Graphics.DrawLine(new Pen(Brushes.Black), headerRect.Location, new Point(headerRect.Location.X + headerRect.Width, headerRect.Location.Y));
        }
    }

}

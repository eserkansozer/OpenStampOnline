//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StampOnline.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class OStamp : ICloneable
    {
        public OStamp()
        { }

        public int Id { get; set; }
        public bool IsTemplate { get; set; }
        public string Alignment { get; set; }
        public string Border { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int NumberOfRows { get; set; }
        public string VAlign { get; set; }
        public string PadColour { get; set; }
        public string HandleColour { get; set; }
        public string PdfUrl { get; set; }
        public string PreviewUrl { get; set; }
    
        public virtual Order Order { get; set; }
        public virtual Graphic Graphic { get; set; }
        public virtual ICollection<StampLine> StampLines { get; set; }

        public object Clone( )
        {
            var clone = new OStamp();
            clone.IsTemplate = false;
            clone.Alignment = this.Alignment;
            clone.Border = this.Border;
            clone.Length = this.Length;
            clone.Width = this.Width;
            clone.NumberOfRows = this.NumberOfRows;
            clone.VAlign = this.VAlign;
            clone.PadColour = this.PadColour;
            clone.HandleColour = this.HandleColour;
            clone.PdfUrl = String.Empty;
            clone.Graphic = this.Graphic != null ? (Graphic)this.Graphic.Clone( ) : new Graphic();
            clone.Order = new Order(clone);
            clone.StampLines = new List<StampLine>();
            foreach (var stampLine in this.StampLines)
            {
                var newStampLine = (StampLine)stampLine.Clone();
                newStampLine.OStamp = this;
                clone.StampLines.Add(newStampLine);
            }
            return clone;
        }
    }
}

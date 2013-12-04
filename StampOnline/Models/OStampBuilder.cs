using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StampOnline.Models
{
    public class OStampBuilder
    {
        private OStamp _oStamp;
        
        public OStampBuilder()
        {
            _oStamp = new OStamp();
        }

        public OStampBuilder WithDefaultValues()
        {
            _oStamp.IsTemplate = false;
            _oStamp.Alignment = "Left";
            _oStamp.Border = "NoBorder";
            _oStamp.Length = 100;
            _oStamp.Width = 200;
            _oStamp.NumberOfRows = 5;
            _oStamp.VAlign = "Center";
            _oStamp.PadColour = "Black";
            _oStamp.HandleColour = "Blue";
            _oStamp.PdfUrl = "";
            _oStamp.Graphic = null;
            _oStamp.Order = new Order(_oStamp);
            _oStamp.StampLines = new HashSet<StampLine>();
            for (int i = 1; i <= _oStamp.NumberOfRows; i++)
            {
                _oStamp.StampLines.Add(new StampLine(_oStamp, i));
            }

            return this;
        }

        public OStamp Build()
        {
            return _oStamp;
        }
    }
}
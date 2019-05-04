using System;

namespace Reports.Domain
{
    public class Indicator
    {
        public Guid Id { get; set; }
        public string Color { get; set; }
        public Component Component { get; set;}

        public bool IsValidIndicator(Indicator indicator){
            return indicator != null;
        }
    }
}
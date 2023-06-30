using System;

namespace ColorsManagment.Infrastructure.Data.DataEntity
{
    public class ColorDataEntity
    {
        public string Color { get; set; } = string.Empty;

        public int NumericValue { get; set; }

        public string DefaultValue { get; set; } = string.Empty;

        public DateTime CurrentDate { get; set; } = new DateTime();
    }
}

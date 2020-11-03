using System;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private const string invalidMessage = "{0} cannot be zero or negative.";
        private double length;
        private double width;
        private double height;

        public Box(double lenght, double width, double height)
        {
            this.Length = lenght;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get
            {
                return this.length;
            }
            private set
            {
                ValidationSide(value, nameof(Length));
                this.length = value;
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                ValidationSide(value, nameof(Width));
                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                ValidationSide(value, nameof(Height));
                this.height = value;
            }
        }

        private void ValidationSide(double value, string side)
        {
            if (value <= 0)
            {
                throw new ArgumentException(string.Format(invalidMessage, side));
            }
        }

        public double CalculeteSurfaceArea()
        {
            return (2 * this.Length * this.Width) + this.CalculeteLateralSurfaceArea();
        }

        public double CalculeteLateralSurfaceArea()
        {
            return 2 * (this.Length * this.Height + this.Width * this.Height);
        }

        public double CalculeteVolume()
        {
            return this.Length * this.Width * this.Height;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder
                .AppendLine($"Surface Area - {this.CalculeteSurfaceArea():F2}")
                .AppendLine($"Lateral Surface Area - {this.CalculeteLateralSurfaceArea():F2}")
                .AppendLine($"Volume - {this.CalculeteVolume():F2}");

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
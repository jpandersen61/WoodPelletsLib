namespace WoodPelletsLib
{
    public class WoodPellet
    {
        public int Id { get; set; }
        public string? Brand { get; set; }
        public int Price { get; set; }
        public int Quality { get; set; }

        public WoodPellet(int Id,string? Brand, int Price,int Quality )
        {
            this.Id = Id;
            this.Brand = Brand;
            this.Price = Price;
            this.Quality = Quality;
        }

        public void ValidateBrand()
        {
            if (Brand == null) throw new ArgumentNullException("Brand NOT allowed to be null");
            
            if (Brand.Length < 2) throw new ArgumentOutOfRangeException("Brand must be at least 2 long");
        }

        public void ValidatePrice()
        {
            if (Price <= 0)
            {
                throw new ArgumentOutOfRangeException("Price must be positive");
            }
        }

        public void ValidateQuality()
        {
            if (Quality >= 1 && Quality <= 5)
            {
                //OK
            }
            else
            {
                throw new ArgumentOutOfRangeException("Quality must be between 1 and 5, both inclusive");
            }
        }

        public void Validate()
        {
            ValidateQuality();
            ValidatePrice();
            ValidateQuality();
        }

        public override string ToString()
        {
            return $"Id: {Id}, Brand: {Brand}, Price: {Price}, Quality: {Quality}";
        }
    }
}
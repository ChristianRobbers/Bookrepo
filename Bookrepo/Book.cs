namespace Bookrepo
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int Price { get; set; }


        public void ValidateTitle()
        {
            if(Title == null)
            {
                throw new ArgumentNullException("Title cant be null");
            }

            if(Title.Length <= 3) 
            { 
                throw new ArgumentOutOfRangeException("Title must contain atleast 3 characters");
            }
        }

        public void ValidatePrice()
        {

            if (Price <= 0)
            {
                throw new ArgumentOutOfRangeException("The price must be greater than 0");
            }

            if (Price >= 1200)
            {
                throw new ArgumentOutOfRangeException("The price must be lesser than or equal to 1200");
            }

        }

        public override string ToString()
        {
            return $"id: {Id} Title: {Title} Price: {Price}";

        }
    }
}